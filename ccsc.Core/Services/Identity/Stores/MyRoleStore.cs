using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ccsc.Core.Services.Identity.Stores
{
	public class MyRoleStore : RoleStore<Role, CcscContext, int, UserRole, RoleClaim>
	{
		public MyRoleStore(CcscContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
}