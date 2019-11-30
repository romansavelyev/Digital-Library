using System.IdentityModel.Tokens.Jwt;
using DigitalLibrary.API.Model;
using DigitalLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.API.Controllers
{
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly LoginService _loginService;

		public AuthController(LoginService loginService)
		{
			_loginService = loginService;
		}

		[HttpPost]
	    [Route("login")]
		public IActionResult Login([FromBody] LoginModel model)
		{
			var (isValid, token) = _loginService.ValidateUser(model);
			if (!isValid.Result)
				return Unauthorized();

			return Ok(new
			{
				token = new JwtSecurityTokenHandler().WriteToken(token),
				expiration = token.ValidTo
			});

		}
    }
}