using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(ILogger<CategoriesController> _logger) 
	: ControllerBase {	

	[HttpGet]
	public ActionResult<IEnumerable<CategoryDTO>> GetCategories() {
		return Ok(MyDataStore.Current.Categories);
	}

	[HttpGet("{id}")]
	public ActionResult<CategoryDTO> GetCategory(int id) {
		throw new Exception("Simon did something wrong!");

		try {
			

			var result = MyDataStore.
				Current.
				Categories.
				FirstOrDefault(c => c.ID == id);

			if (result == null) {
				_logger.LogWarning($"No category with id: {id}");

				return NotFound();
			}

			return Ok(result);
		} catch (Exception ex) {
			_logger.LogCritical($"Exception while calling GetCategory {id}", ex);
			return StatusCode(500, $"Exception whil calling GetCategory {id}");
		}
	}
}
