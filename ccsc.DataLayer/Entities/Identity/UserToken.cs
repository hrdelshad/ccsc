using Microsoft.AspNetCore.Identity;
using System;

namespace ccsc.DataLayer.Entities.Identity
{
	public class UserToken : IdentityUserToken<int>
	{
		public User User { get; set; }

		public DateTime GeneratedOn { get; set; }
	}
}