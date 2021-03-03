using ccsc.DataLayer.Entities.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Services
{
	public class Service
	{
		[Key]
		public int ServiceId { get; set; }

		[Display(Name = "متن")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string text { get; set; }

		[Display(Name = "نوع سرویس")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ServiceTypeId { get; set; }

		[Display(Name = "تاریخ ثبت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public DateTime RegisterDate { get; set; }

		[Display(Name = "وضعیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ServiceStatusId { get; set; }

		[Display(Name = "تاریخ انجام")]
		public DateTime? EndDate { get; set; }

		public int RequestId { get; set; }

		#region Relations

		[Display(Name = "نوع سرویس")]
		public virtual ServiceType ServiceType { get; set; }

		[Display(Name = "وضعیت")]
		public virtual ServiceStatus ServiceStatus { get; set; }

		[Display(Name = "درخواست")]
		public virtual Request Request { get; set; }

		#endregion



	}
}