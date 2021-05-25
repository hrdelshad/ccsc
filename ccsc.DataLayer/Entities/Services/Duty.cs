using ccsc.DataLayer.Entities.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Common;

namespace ccsc.DataLayer.Entities.Services
{
	public class Duty
	{
		[Key]
		public int DutyId { get; set; }

		[Display(Name = "عنوان کار")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "سرویس مربوطه")]
		public int? ServiceId { get; set; }

		[Display(Name = "درخواست مربوطه")]
		public int RequestId { get; set; }

		[Display(Name = "تاریخ ثبت")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DutyDate { get; set; }

		[Display(Name = "موعد انجام")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? DuoDate { get; set; }

		[Display(Name = "تاریخ انجام")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? DoneDate { get; set; }

		[Display(Name = "وضعیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int DutyStatusId { get; set; }

		#region Relations

		[Display(Name = "سرویس مربوطه")]
		public virtual Service Service { get; set; }

		[Display(Name = "درخواست مربوطه")]
		public virtual Request Request { get; set; }

		[Display(Name = "وضعیت")]
		public virtual DutyStatus DutyStatus { get; set; }

		[Display(Name = "توضیحات")]
		public ICollection<Comment> Comments { get; set; }
		#endregion

	}

}
