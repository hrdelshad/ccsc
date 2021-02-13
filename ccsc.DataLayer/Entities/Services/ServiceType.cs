using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

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


		//[Display(Name = "سرویس پایه")]
		//[ForeignKey("ServiceTypeId")]
		//public int? ParentServiceTypeId { get; set; }

		#region Relations

		//[Display(Name = "سرویس پایه")]
		////[ForeignKey("ServiceTypeId")]
		//public virtual ServiceType ParentServiceType { get; set; }

		[Display(Name = "کارها")]
		public ICollection<Duty> Duties { get; set; }

		#endregion
	}
}
