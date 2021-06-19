using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		[HttpPost]
		public IActionResult Post([FromBody] Login login)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("The Model Is Not Valid");
			}

			if(login.UserName.ToLower() != "hamid" || login.Password != "C4936F03-938B-4778-9234-3B004AB03989")
			{
				return Unauthorized();
			}

			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DelVerifyApiEnicoKey"));

			var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var tokenOption = new JwtSecurityToken(
				issuer: "http://localhost/api",
				claims: new List<Claim>
				{
					new Claim(ClaimTypes.Name, login.UserName),
					new Claim(ClaimTypes.Role, "Admin")
				},
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials:signingCredentials
				);
			var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

			return Ok(new { token = tokenString });
		}
	}
}
