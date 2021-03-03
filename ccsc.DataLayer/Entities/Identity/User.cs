using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Identity
{
	public class User : IdentityUser<int>
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string FirstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string LastName { get; set; }

		[Display(Name = "نام نمایشی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string DisplayName { get; set; }

		[Display(Name = "تاریخ عضویت")]
		public DateTime RegisteredOn { get; set; }


		public ICollection<UserRole> Roles { get; set; }

		public ICollection<UserLogin> Logins { get; set; }

		public ICollection<UserClaim> Claims { get; set; }

		public ICollection<UserToken> Tokens { get; set; }

	}
}
