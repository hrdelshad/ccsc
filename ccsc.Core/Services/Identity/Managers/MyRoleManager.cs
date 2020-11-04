using System.Collections.Generic;
using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ccsc.Core.Services.Identity.Managers
{
	public class MyRoleManager : RoleManager<Role>
	{
		public MyRoleManager(
			IRoleStore<Role> store, 
			IEnumerable<IRoleValidator<Role>> roleValidators, 
			ILookupNormalizer keyNormalizer, 
			IdentityErrorDescriber errors, 
			ILogger<RoleManager<Role>> logger) 
			: base(store, roleValidators, keyNormalizer, errors, logger)
		{
		}

	}
}