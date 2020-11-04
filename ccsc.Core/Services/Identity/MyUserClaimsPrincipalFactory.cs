using System.Security.Claims;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ccsc.Core.Services.Identity
{
	public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
	{
		public MyUserClaimsPrincipalFactory(
			UserManager<User> userManager,
			RoleManager<Role> roleManager,
			IOptions<IdentityOptions> options
			) : base(userManager, roleManager, options)
		{
		}


		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
		{
			var claimIdentity = await base.GenerateClaimsAsync(user);
			claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer));
			claimIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
			claimIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
			claimIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

			return claimIdentity;
		}


	}
}