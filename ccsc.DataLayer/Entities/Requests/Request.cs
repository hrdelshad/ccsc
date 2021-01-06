using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Customers;
using ccsc.DataLayer.Entities.Services;

namespace ccsc.DataLayer.Entities.Requests
{
	public class Request
	{
		[Key]
		public int RequestId { get; set; }

		[Display(Name = "مشتری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerId { get; set; }

		[Display(Name = "درخواست کننده")]
		public int? ContactId { get; set; }

		[Display(Name = "تاریخ درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.DateTime)]
		public DateTime RequestTime { get; set; }

		[Display(Name = "کانال درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int RequestChanelId { get; set; }

		[Display(Name = "نوع درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int RequestTypeId { get; set; }

		[Display(Name = "محصول")]
		public int? SubSystemId { get; set; }

		[Display(Name = "وضعیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int RequestStatusId { get; set; }

		[Display(Name = "عنوان درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "متن درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(800, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Text { get; set; }

		#region Relations

		[Display(Name = "مشتری")]
		public virtual Customer Customer { get; set; }

		[Display(Name = "درخواست کننده")]
		public virtual Contact Contact { get; set; }

		[Display(Name = "کانال درخواست")]
		public virtual RequestChannel RequestChanel { get; set; }

		[Display(Name = "نوع درخواست")]
		public virtual RequestType RequestType { get; set; }

		[Display(Name = "محصول")]
		public SubSystem SubSystem { get; set; }

		[Display(Name = "وضعیت")]
		public virtual RequestStatus RequestStatus { get; set; }

		[Display(Name = "فهرست خدمات")]
		public virtual ICollection<Service> Services { get; set; }

		[Display(Name = "فهرست کارها")]
		public virtual ICollection<Duty> Duties { get; set; }

		#endregion
	}
}
