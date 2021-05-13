using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;
using ccsc.DataLayer.Entities.Requests;
using ccsc.DataLayer.Entities.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Customers
{
	[Display(Name = "مشتری")]
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "آدرس سامانه")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Url { get; set; }

		[Display(Name = "ورژن")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Version { get; set; }

		[Display(Name = "ت. بررسی ورژن")]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:H:mm yyyy/MM/dd}", ApplyFormatInEditMode = false)]
		public DateTime? VersionCheckDate { get; set; }

		[Display(Name = "کاربری پیامک")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string SmsUser { get; set; }

		[Display(Name = "پسورد پیامک")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string SmsPass { get; set; }

		[Display(Name = "اعتبار پیامک")]
		[Column(TypeName = "decimal(18, 0)")]
		[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
		[DefaultValue("0")]
		public decimal SmsCredit { get; set; }

		[Display(Name = "کف اعتبار")]
		[Column(TypeName = "decimal(18, 0)")]
		[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
		[DefaultValue("1000000")]
		public decimal MinSmsCredit { get; set; }

		[Display(Name = "بررسی پیامک")]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:H:mm yyyy/MM/dd}", ApplyFormatInEditMode = true)]
		public DateTime? SmsCreditCheckDate { get; set; }

		[Display(Name = "پیامک؟")]
		public bool IsActiveSms { get; set; }

		[Display(Name = "ارسال پس از")]
		[DefaultValue("3")]
		public int AfterXDay { get; set; }

		[Display(Name = "ت. ارسال پیامک")]
		[DataType(DataType.Date)]
		public DateTime? SendSmsDate { get; set; }

		[Display(Name = "شسناسه")]
		public int? UniversityCode { get; set; }

		[Display(Name = "کد")]
		public int? UniversityId { get; set; }

		[Display(Name = "قرارداد پشتیبانی نشده")]
		public bool HasUnSupportedContract { get; set; }


		#region Relations

		[Display(Name = "وضعیت")]
		//[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerStatusId { get; set; }

		[Display(Name = "وضعیت")]
		public CustomerStatus CustomerStatus { get; set; }

		[Display(Name = "نوع")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerTypeId { get; set; }

		[Display(Name = "نوع")]
		public CustomerType CustomerType { get; set; }

		[Display(Name = "ریموت‌ها")]
		public ICollection<Server> Servers { get; set; }

		public ICollection<Contract> Contracts { get; set; }

		public ICollection<Service> Services { get; set; }

		public ICollection<Request> Requests { get; set; }

		public ICollection<Contact> Contacts { get; set; }

		#endregion

	}
}
