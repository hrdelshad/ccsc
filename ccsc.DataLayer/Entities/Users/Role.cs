using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Users
{
	public class Role
	{
		public Role()
		{
				
		}

		[Key]
		public int RoleId { get; set; }
		
		[Display(Name = "نقش")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		#region Relations

		public List<UserRole> UserRoles { get; set; }

		#endregion
	}
}
