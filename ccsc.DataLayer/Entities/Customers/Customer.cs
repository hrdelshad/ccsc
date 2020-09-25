using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ccsc.DataLayer.Entities.Customers
{
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }


		public int CustomerTypeId { get; set; }


		public string Url { get; set; }
		public string Version { get; set; }
		public DateTime? VersionCheckDate { get; set; }
		public string SMSUser { get; set; }
		public string SMSPass { get; set; }
		public decimal SMSCredit { get; set; }
		public decimal MinSMSCredit { get; set; }
		public DateTime? SMSCreditCheckDate { get; set; }
		public bool IsActiveSms { get; set; }
		public int AfterXDay { get; set; }
		public DateTime? SendSmsDate { get; set; }

		public int? UniversityId { get; set; }

		#region Relations

		[Display(Name = "نوع")]
		public virtual CustomerType CustomerType { get; set; }

		public List<Server> Servers { get; set; }

		#endregion

	}
}
