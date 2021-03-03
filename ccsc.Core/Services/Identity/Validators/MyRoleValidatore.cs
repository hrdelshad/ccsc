using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Identity.Validators
{
	public class MyRoleValidatore : RoleValidator<Role>
	{
		public MyRoleValidatore(IdentityErrorDescriber errors) : base(errors)
		{
			
		}

		public override Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
		{
			return base.ValidateAsync(manager, role);
		}
	}
}