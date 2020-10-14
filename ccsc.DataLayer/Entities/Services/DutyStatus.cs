using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace ccsc.DataLayer.Entities.Services
{
	public class DutyStatus
	{
		[Key]
		public int DutyStatusId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "فعال")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool IsOpen { get; set; } = true;
	}
}
