using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ccsc.Core.Services.Identity.Managers
{
	public class MySignInManager : SignInManager<User>
	{
		public MySignInManager(
			UserManager<User> userManager,
			IHttpContextAccessor contextAccessor,
			IUserClaimsPrincipalFactory<User> claimsFactory,
			IOptions<IdentityOptions> optionsAccessor,
			ILogger<SignInManager<User>> logger,
			IAuthenticationSchemeProvider schemes
			
			) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
		{
		}
	}
}