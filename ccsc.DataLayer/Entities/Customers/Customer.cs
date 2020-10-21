using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

		[Display(Name = "نوع")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerTypeId { get; set; }

		[Display(Name = "آدرس سامانه")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Url { get; set; }

		[Display(Name = "ورژن")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Version { get; set; }

		[Display(Name = "ت. بررسی ورژن")]
		public DateTime? VersionCheckDate { get; set; }

		[Display(Name = "کاربری پیامک")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string SMSUser { get; set; }

		[Display(Name = "پسورد پیامک")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string SMSPass { get; set; }

		[Display(Name = "اعتبار پیامک")]
		[Column(TypeName = "decimal(18, 0)")]
		public decimal SMSCredit { get; set; }

		[Display(Name = "کف اعتبار")]
		[Column(TypeName = "decimal(18, 0)")]
		public decimal MinSMSCredit { get; set; }

		[Display(Name = "زمان بررسی اعتبار پیامک")]
		public DateTime? SMSCreditCheckDate { get; set; }

		[Display(Name = "پیامک؟")]
		public bool IsActiveSms { get; set; }

		[Display(Name = "ارسال پس از")]
		public int AfterXDay { get; set; }

		[Display(Name = "ت. ارسال پیامک")]
		public DateTime? SendSmsDate { get; set; }

		[Display(Name = "کد")]
		public int? UniversityId { get; set; }

		#region Relations

		[Display(Name = "نوع")]
		public CustomerType CustomerType { get; set; }
		[Display(Name = "ریموت‌ها")]
		public List<Server> Servers { get; set; }

		#endregion

	}
}
