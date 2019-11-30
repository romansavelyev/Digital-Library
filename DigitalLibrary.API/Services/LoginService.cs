using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.API.Model;
using DigitalLibrary.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DigitalLibrary.API.Services
{
    public class LoginService
    {
	    private readonly UserManager<ApplicationUser> _userManager;
	    private readonly ApplicationUserRepository _applicationUserRepository;

		public LoginService(UserManager<ApplicationUser> userManager,
			ApplicationUserRepository applicationUserRepository
			)
		{
			_userManager = userManager;
			_applicationUserRepository = applicationUserRepository;
		}

	    public (Task<bool>, JwtSecurityToken) ValidateUser(LoginModel model)
	    {
		    var user = _userManager.FindByEmailAsync(model.Email);
		    if (user == null || !_userManager.CheckPasswordAsync(user.Result, model.Password).Result)
			    return (Task.FromResult(false), null);

		    var token = CreateToken(user.Result);
		    return (Task.FromResult(true), token);
	    }

	    private static JwtSecurityToken CreateToken(ApplicationUser user)
	    {
		    var claims = new[]
		    {
			    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
			    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		    };

		    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DigitalLibraryKey"));

		    var token = new JwtSecurityToken(
			    expires: DateTime.UtcNow.AddHours(1),
			    claims: claims,
			    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
		    );

		    return token;
	    }


    }
}
