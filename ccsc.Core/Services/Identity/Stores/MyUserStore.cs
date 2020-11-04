using System.Threading;
using System.Threading.Tasks;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ccsc.Core.Services.Identity.Stores
{
	public class MyUserStore : UserStore<User, Role, CcscContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
	{
		public MyUserStore(CcscContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}

	}
}