﻿using Microsoft.AspNetCore.Identity;
using System;

namespace ccsc.DataLayer.Entities.Identity
{
	public class UserRole : IdentityUserRole<int>
	{
		public User User { get; set; }

		public Role Role { get; set; }

		public DateTime GivenOn { get; set; }


	}
}
