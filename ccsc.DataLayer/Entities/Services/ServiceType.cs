using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ccsc.DataLayer.Entities.Services
{
	public class ServiceType
	{
		[Key]
		public int ServiceTypeId { get; set; }

		[Display(Name = "نوع سرویس")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "سرویس پایه")]
		public int? ParentServiceTypeId { get; set; }

		#region Relations

		[Display(Name = "سرویس پایه")]
		public ServiceType ParentServiceType { get; set; }

		[Display(Name = "کارها")]
		public virtual ICollection<Duty> Duties { get; set; }

		#endregion
	}
}
