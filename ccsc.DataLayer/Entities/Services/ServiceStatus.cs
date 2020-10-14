using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ccsc.DataLayer.Entities.Services
{
	public class ServiceStatus
	{
		[Key]
		public int ServiceStatusId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string title { get; set; }

	}
}
