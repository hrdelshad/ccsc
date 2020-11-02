using System;
using Microsoft.AspNetCore.Identity;

namespace ccsc.DataLayer.Entities.Identity
{
	public class UserLogin : IdentityUserLogin<int>
	{
		public User User { get; set; }

		public DateTime LogedOn { get; set; }

	}
}