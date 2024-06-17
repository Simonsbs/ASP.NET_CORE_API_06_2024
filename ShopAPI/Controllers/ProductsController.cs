using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Entities;
using ShopAPI.Models;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories/{categoryID}/products")]
public class ProductsController : ControllerBase {
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
	public ActionResult PatchProduct(int categoryID,
		int productID,
		JsonPatchDocument<ProductForUpdateDTO> patchDocument) {

		var category = MyDataStore.Current.Categories.FirstOrDefault(c => c.ID == categoryID);
		if (category == null) {
			return NotFound("Category not found inorder to update the product");
		}

		var product = category.Products.FirstOrDefault(p => p.ID == productID);
		if (product == null) {
			return NotFound("Product not found");
		}

		var productToUpdate = new ProductForUpdateDTO() {
			Name = product.Name,
			Description = product.Description
		};

		patchDocument.ApplyTo(productToUpdate, ModelState);

		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}

		if (!TryValidateModel(productToUpdate)) {
			return BadRequest(ModelState);
		}

		product.Name = productToUpdate.Name;
		product.Description = productToUpdate.Description;

		return NoContent();
	}

	[HttpDelete("{productID}")]
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
