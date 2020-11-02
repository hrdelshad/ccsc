using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ccsc.DataLayer.Entities.Identity
{
	public class Role : IdentityRole<int>
	{
		public Role()
		{
				
		}

		[Display(Name = "نقش")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }


		public DateTime CreatedOn { get; set; }


		public ICollection<RoleClaim> Claims { get; set; }

		public ICollection<UserRole> Users { get; set; }


	}
}
