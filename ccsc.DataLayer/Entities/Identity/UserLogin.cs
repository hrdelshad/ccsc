using Microsoft.AspNetCore.Identity;
using System;

namespace ccsc.DataLayer.Entities.Identity
{
	public class UserLogin : IdentityUserLogin<int>
	{
		public User User { get; set; }

		public DateTime LogedOn { get; set; }

	}
}