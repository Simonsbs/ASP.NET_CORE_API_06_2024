using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopAPI.Entities;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/v{version:ApiVersion}/authentication")]
[ApiVersion(1)]
[ApiVersion(2)]
public class AuthenticationController(
	ILogger<AuthenticationController> _logger,
	IUserRepository _repo,
	IConfiguration _config) : ControllerBase {

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
			.FromBase64String(_config["Authentication:MyKey"])
		);

		SigningCredentials creds = new SigningCredentials(
			key, 
			SecurityAlgorithms.HmacSha256
		);

		JwtSecurityToken token = new JwtSecurityToken(
			_config["Authentication:Issuer"],
			_config["Authentication:Audience"],
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
