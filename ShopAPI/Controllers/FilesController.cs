using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase {
	private FileExtensionContentTypeProvider _typeProvider;

	public FilesController(
		FileExtensionContentTypeProvider typeProvider) {
		_typeProvider = typeProvider ?? 
			throw new ArgumentNullException(nameof(typeProvider));
	}

	[HttpGet("{path}")]
	public ActionResult GetFile(string path) {
		//string path = "File1.pdf";

		if (!System.IO.File.Exists(path)) {
			return NotFound();
		}

		if(!_typeProvider.
			TryGetContentType(path, out string contentType)) {
			contentType = "application/octet-stream";
		}

		var bytes = System.IO.File.ReadAllBytes(path);
		return File(bytes, contentType, Path.GetFileName(path));
	}
}
