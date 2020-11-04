using System;
using System.ComponentModel.DataAnnotations;

namespace ccsc.Core.DTOs.Account
{
	public class RegisterAccountViewModel
	{
		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string UserName { get; set; }

		[Display(Name = "نام نمایشی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string DisplayName { get; set; }

		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string FirstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string LastName { get; set; }

		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی‌باشد")]
		public string Email { get; set; }

		[Display(Name = "رمز")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "تکرار رمز")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }

		public DateTime RegisteredOn { get; set; }
	}
}