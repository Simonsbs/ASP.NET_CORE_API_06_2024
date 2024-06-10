using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase {
	[HttpGet]
	public JsonResult GetCategories() {
		return new JsonResult(MyDataStore.Current.Categories);
	}

	[HttpGet("{id}")]
	public JsonResult GetCategory(int id) {
		var result = MyDataStore.
			Current.
			Categories.
			FirstOrDefault(c => c.ID == id);
		return new JsonResult(result);
	}
}
