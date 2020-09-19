using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Products;

namespace ccsc.DataLayer.Entities.Requests
{
	public class Request
	{
		[Key]
		public int RequestId { get; set; }

		[Display(Name = "درخواست کننده")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ContactId { get; set; }

		[Display(Name = "تاریخ درخواست")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public DateTime RequestTime { get; set; }

		[Display(Name = "کانال درخواست")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int RequestChanelId { get; set; }

		[Display(Name = "نوع درخواست")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int RequestTypeId { get; set; }

		[Display(Name = "محصول")]
		public int? ProductId { get; set; }

		[Display(Name = "وضعیت")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int RequestStatusId { get; set; }

		[Display(Name = "متن درخواست")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Content { get; set; }

		#region Relations

		[Display(Name = "درخواست کننده")]
		public virtual Contact Contact { get; set; }

		[Display(Name = "کانال درخواست")]
		public virtual RequestChanel RequestChanel { get; set; }
		
		[Display(Name = "نوع درخواست")]
		public virtual RequestType RequestType { get; set; }
		
		[Display(Name = "محصول")]
		public virtual Product Product { get; set; }
		
		[Display(Name = "وضعیت")]
		public virtual RequestStatus RequestStatus { get; set; }

		#endregion
	}
}
