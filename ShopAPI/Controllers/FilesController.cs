using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase {
	[HttpGet("{name}")]
	public void GetFile(string name) {

	}
}
