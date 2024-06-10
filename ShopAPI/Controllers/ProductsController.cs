using System.Collections;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories/{categoryID}/products")]
public class ProductsController : ControllerBase {
	[HttpGet]
	public ActionResult<IEnumerable<ProductDTO>> GetProducts(int categoryID) {
		var products = MyDataStore.Current.Categories
			.FirstOrDefault(c => c.ID == categoryID)?
			.Products;

		if (products == null) {
			return NotFound();
		}

		return Ok(products);
	}
}
