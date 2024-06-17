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
	ICategoryRepository _repo)
	: ControllerBase {

	[HttpGet]
	public async Task<ActionResult<IEnumerable<CategoryWithoutProductsDTO>>> GetCategories() {
		IEnumerable<Entities.Category> categories = await _repo.GetCategoriesAsync();

		var results = new List<CategoryWithoutProductsDTO>();
		foreach (Entities.Category category in categories) {
			results.Add(new CategoryWithoutProductsDTO {
				ID = category.ID,
				Name = category.Name,
				Description = category.Description
			});
		}

		return Ok(results);
	}

	[HttpGet("{id}")]
	public ActionResult<CategoryDTO> GetCategory(int id) {
		var result = MyDataStore.
			Current.
			Categories.
			FirstOrDefault(c => c.ID == id);

		if (result == null) {
			_logger.LogWarning($"No category with id: {id}");
			_mailService.Send("Missing Category", $"No category with id: {id}");
			return NotFound();
		}

		return Ok(result);
	}
}
