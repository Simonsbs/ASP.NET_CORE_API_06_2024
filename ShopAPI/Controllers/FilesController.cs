using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase {
	[HttpGet("{name}")]
	public ActionResult GetFile(string name) {
		string path = "File1.pdf";

		if (!System.IO.File.Exists(path)) {
			return NotFound();
		}

		var bytes = System.IO.File.ReadAllBytes(path);
		return File(bytes, "text/plain");
	}
}
