using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(
	ILogger<CategoriesController> _logger,
	IMailService _mailService,
	ICategoryRepository _repo,
	IMapper _mapper)
	: ControllerBase {

	[HttpGet]
	public async Task<ActionResult<IEnumerable<CategoryWithoutProductsDTO>>> GetCategories() {
		IEnumerable<Entities.Category> categories = await _repo.GetCategoriesAsync();
		var results = _mapper.Map<IEnumerable<CategoryWithoutProductsDTO>>(categories);
		return Ok(results);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetCategory(int id, bool includeProducts = false) {
		var category = await _repo.GetCategoryAsync(id, includeProducts);
		if (category == null) {
			return NotFound();
		}

		if (includeProducts) {
			return Ok(_mapper.Map<CategoryDTO>(category));
		}

		return Ok(_mapper.Map<CategoryWithoutProductsDTO>(category));
	}
}
