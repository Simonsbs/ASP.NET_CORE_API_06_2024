using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopAPI.Entities;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController(
	ILogger<AuthenticationController> _logger,
	IUserRepository _repo) : ControllerBase {

	public class AuthenticationRequest {
        public string Username { get; set; }
        public string Password { get; set; }
    }

	[HttpPost]
	public async Task<ActionResult<string>> GetToken(AuthenticationRequest request) {
		User? user = await _repo.AuthenticateUserAsync(request.Username, request.Password);

		if (user == null) {
			return Unauthorized();
		}

		List<Claim> claims = new List<Claim>() {
			new Claim("sub", user.ID.ToString()),
			//new Claim("Name", user.Name), // Maybe
			//new Claim("email", user.Email), // Maybe
			new Claim("auth_level", user.AuthLevel.ToString()),
			//new Claim("user", user.Username), // DONT!!!!
			//new Claim("pass", user.Password) // DONT!!!!
		};

		SymmetricSecurityKey key = new SymmetricSecurityKey(
			Convert
			.FromBase64String("w8u//VCX+Em49CJqLK+YFLqF+uAMej+xeKVGTNreIVk=")
		);

		SigningCredentials creds = new SigningCredentials(
			key, 
			SecurityAlgorithms.HmacSha256
		);

		JwtSecurityToken token = new JwtSecurityToken(
			"https://localhost:7234",
			"ShopUsers",
			claims,
			DateTime.UtcNow,
			DateTime.UtcNow.AddDays(1),
			creds
			);

		JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
		string rawToken = handler.WriteToken(token);

		return Ok(rawToken);
	}

}
