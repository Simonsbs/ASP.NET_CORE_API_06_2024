using System.Collections;
using System.Text.Json;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Entities;
using ShopAPI.Models;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
//[Authorize]
[ApiVersion(1)]
[ApiVersion(2)]
[Route("api/categories/{categoryID}/products")]
public class ProductsController : ControllerBase {
	const int MAX_PAGE_SIZE = 2;

	private ILogger<ProductsController> _logger;
	private IMailService _mailService;
	private IProductRepository _repo;
	private IMapper _mapper;

	public ProductsController(ILogger<ProductsController> logger, IMailService mailService, IProductRepository repo, IMapper mapper) {
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
		_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

		//var log = HttpContext.RequestServices.GetService(typeof(ILogger<ProductsController>));
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts(int categoryID) {
		if (!await _repo.CheckCategoryExists(categoryID)) {
			return NotFound("Category not found");
		}

		IEnumerable<Product> result = await _repo.GetProductsForCategoryAsync(categoryID);

		return Ok(_mapper.Map<IEnumerable<ProductDTO>>(result));
	}

	[HttpGet("/api/products")]
	public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(
			string? name,
			string? query,
			int pageNumber = 1,
			int pageSize = 2
		) {
		if (pageSize > MAX_PAGE_SIZE) {
			pageSize = MAX_PAGE_SIZE;
		}

		// not the best policy implementation
		//if (int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "auth_level")?.Value, out int authLevel)) {
		//	if (authLevel != 9) {
		//		return Unauthorized();
		//	}
		//}

		var (results, meta) = await _repo.GetProductsAsync(name, query, pageNumber, pageSize);

		// Not recomended !!!
		// var results = _repo.GetProductsQuery();

		//Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(meta));

		Response.Headers.Add("X-TotalItemCount", meta.TotalItemCount.ToString());
		Response.Headers.Add("X-TotalPageCount", meta.TotalPageCount.ToString());
		Response.Headers.Add("X-PageSize", meta.PageSize.ToString());
		Response.Headers.Add("X-PageNumber", meta.PageNumber.ToString());
		Response.Headers.Add("X-CurrentPageCount", meta.CurrentPageCount.ToString());

		return Ok(_mapper.Map<IEnumerable<ProductDTO>>(results));
	}

	[HttpGet("{productID}", Name = "GetSingleProduct")]
	public async Task<ActionResult<ProductDTO>> GetProduct(int categoryID, int productID) {
		if (!await _repo.CheckCategoryExists(categoryID)) {
			return NotFound("Category not found");
		}

		Product? result = await _repo.GetProductForCategoryAsync(categoryID, productID);
		if (result == null) {
			return NotFound("No such product in the category");
		}

		return Ok(_mapper.Map<ProductDTO>(result));
	}

	[HttpPost]
	public async Task<ActionResult<ProductDTO>> CreateProduct(
		int categoryID,
		ProductForCreationDTO productToCreate) {

		if (!await _repo.CheckCategoryExists(categoryID)) {
			return NotFound("Category not found");
		}

		Product prod = _mapper.Map<Product>(productToCreate);

		await _repo.AddProductForCategoryAsync(categoryID, prod);

		ProductDTO productDTO = _mapper.Map<ProductDTO>(prod);

		return CreatedAtRoute(
				"GetSingleProduct",
				new {
					categoryID,
					productID = productDTO.ID,
				},
				productDTO
			);
	}

	[HttpPut("{productID}")]
	public async Task<ActionResult> UpdateProduct(int categoryID, int productID, ProductForUpdateDTO updatedProduct) {
		if (!await _repo.CheckCategoryExists(categoryID)) {
			return NotFound("Category not found");
		}

		Product? product = await _repo.GetProductForCategoryAsync(categoryID, productID);
		if (product == null) {
			return NotFound("Product not found");
		}

		_mapper.Map(updatedProduct, product);

		await _repo.SaveChangesAsync();

		return NoContent();
	}

	[HttpPatch("{productID}")]
	public async Task<ActionResult> PatchProduct(int categoryID,
		int productID,
		JsonPatchDocument<ProductForUpdateDTO> patchDocument) {

		if (!await _repo.CheckCategoryExists(categoryID)) {
			return NotFound("Category not found");
		}

		Product? product = await _repo.GetProductForCategoryAsync(categoryID, productID);
		if (product == null) {
			return NotFound("Product not found");
		}

		ProductForUpdateDTO productForUpdate = _mapper.Map<ProductForUpdateDTO>(product);

		patchDocument.ApplyTo(productForUpdate, ModelState);

		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}

		if (!TryValidateModel(productForUpdate)) {
			return BadRequest(ModelState);
		}

		_mapper.Map(productForUpdate, product);

		await _repo.SaveChangesAsync();

		return NoContent();
	}

	[HttpDelete("{productID}")]
	//[Authorize(Policy = "IsSimon")]
	public async Task<ActionResult> DeleteProduct(int categoryID, int productID) {
		if (!await _repo.CheckCategoryExists(categoryID)) {
			return NotFound("Category not found");
		}

		Product? product = await _repo.GetProductForCategoryAsync(categoryID, productID);
		if (product == null) {
			return NotFound("Product not found");
		}

		await _repo.DeleteProduct(product);

		return NoContent();
	}
}
