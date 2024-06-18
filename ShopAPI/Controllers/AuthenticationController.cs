using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase {
	public class AuthenticationRequest {
        public string Username { get; set; }
        public string Password { get; set; }
    }

	[HttpPost]
	public ActionResult GetToken(AuthenticationRequest request) {

		return Ok();
	}

}
