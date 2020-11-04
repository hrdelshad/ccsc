﻿using System.ComponentModel.DataAnnotations;

namespace ccsc.Core.DTOs.Account
{
	public class LoginViewModel
	{
		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string UserName { get; set; }

		[Display(Name = "رمز")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "مرا به خاطر بسپار")]
		public bool RememberMe { get; set; }
	}
}