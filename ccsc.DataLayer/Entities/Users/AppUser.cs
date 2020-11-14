using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Users
{
	public class AppUser
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int AppUserId { get; set; }

		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string UserName { get; set; }

		[Display(Name = "نام نمایشی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string DisplayName { get; set; }

		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Email { get; set; }

		[Display(Name = "رمز")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Password { get; set; }

		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		[Display(Name = "کد فعالسازی")]
		public string ActiveCode { get; set; }

		[Display(Name = "وضعیت")]
		public bool IsActive { get; set; }

		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		[Display(Name = "آواتار")]
		public string UserAvatar { get; set; }

		[Display(Name = "تاریخ عضویت")]
		public DateTime RegisterDate { get; set; }

	}
}
