using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(
	ILogger<CategoriesController> _logger,
	IMailService _mailService)
	: ControllerBase {

	[HttpGet]
	public ActionResult<IEnumerable<CategoryDTO>> GetCategories() {
		return Ok(MyDataStore.Current.Categories);
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
