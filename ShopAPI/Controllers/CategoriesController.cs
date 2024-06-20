using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/v{version:ApiVersion}/categories")]
[ApiVersion(2)]
public class CategoriesController(
		ILogger<CategoriesController> _logger,
		IMailService _mailService,
		ICategoryRepository _repo,
		IMapper _mapper)
		: ControllerBase {

	/// <summary>
	/// Retrieves all categories.
	/// </summary>
	/// <returns>A list of categories without products.</returns>
	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<CategoryWithoutProductsDTO>), 200)]
	public async Task<ActionResult<IEnumerable<CategoryWithoutProductsDTO>>> GetCategories() {
		IEnumerable<Entities.Category> categories = await _repo.GetCategoriesAsync();
		var results = _mapper.Map<IEnumerable<CategoryWithoutProductsDTO>>(categories);
		return Ok(results);
	}


	/// <summary>
	/// Retrieves a category by its ID.
	/// </summary>
	/// <param name="id">The ID of the category.</param>
	/// <returns>The category with or without products.</returns>
	/// <response code="200">Returns the category</response>
	[HttpGet("{id}/withproducts/")]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<CategoryDTO>> GetCategory(int id) {
		return await GetCategorySharedAsync<CategoryDTO>(id);
	}

	/// <summary>
	/// Retrieves a category by its ID.
	/// </summary>
	/// <param name="id">The ID of the category.</param>
	/// <returns>The category with or without products.</returns>
	/// <response code="200">Returns the category</response>
	[HttpGet("{id}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<CategoryWithoutProductsDTO>> GetCategoryWithoutProducts(int id) {
		return await GetCategorySharedAsync<CategoryWithoutProductsDTO>(id, false);
	}

	private async Task<ActionResult<T>> GetCategorySharedAsync<T>(int id, bool includeProducts = true) {
		var category = await _repo.GetCategoryAsync(id, includeProducts);
		if (category == null) {
			return NotFound();
		}

		return Ok(_mapper.Map<T>(category));
	}
}
