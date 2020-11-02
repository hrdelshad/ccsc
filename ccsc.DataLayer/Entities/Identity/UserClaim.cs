using Microsoft.AspNetCore.Identity;

namespace ccsc.DataLayer.Entities.Identity
{
	public class UserClaim : IdentityUserClaim<int>
	{
		public User User { get; set; }
	}
}