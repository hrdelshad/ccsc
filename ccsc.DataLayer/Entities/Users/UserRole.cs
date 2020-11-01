﻿using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Users
{
	public class UserRole
	{
		public UserRole()
		{
			
		}

		[Key]
		public int UR_id { get; set; }
		public int UserId { get; set; }
		public int RoleId { get; set; }

		#region Relations

		public virtual User User { get; set; }
		public virtual Role Role { get; set; }
		#endregion
	}
}
