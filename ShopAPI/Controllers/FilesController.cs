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

		if (!_typeProvider.
			TryGetContentType(path, out string contentType)) {
			contentType = "application/octet-stream";
		}

		var bytes = System.IO.File.ReadAllBytes(path);
		return File(bytes, contentType, Path.GetFileName(path));
	}

	[HttpPost]
	public async Task<ActionResult> CreateFile(IFormFile file) {
		if (file.Length == 0 ||
			file.Length > 2000000 ||
			file.ContentType != "application/pdf") {

			return BadRequest("File must be less than 2Mb and of pdf type");
		}

		string path = Path.Combine(
			Directory.GetCurrentDirectory(),
			Guid.NewGuid() + ".pdf");

		using (var stream = new FileStream(path, FileMode.Create)) {
			await file.CopyToAsync(stream);
		}

		return Ok("File uploaded");
	}
}
