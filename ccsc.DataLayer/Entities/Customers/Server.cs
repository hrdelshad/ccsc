using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Common;

namespace ccsc.DataLayer.Entities.Customers
{
	public class Server
	{
		[Key]
		public int ServerId { get; set; }

		[Display(Name = "نوع سرور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ServerTypeId { get; set; }

		[Display(Name = "سیستم عامل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int OsId { get; set; }

		[Display(Name = "رم")]
		public int Ram { get; set; }

		[Display(Name = "سی پی یو")]
		public string Cpu { get; set; }

		[Display(Name = "ظرفیت هارد")]
		public int Hard { get; set; }

		[Display(Name = "آدرس ریموت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Url { get; set; }

		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string UserName { get; set; }

		[Display(Name = "رمز")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Password { get; set; }

		[Display(Name = "وی پی ان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool Vpn { get; set; }

		[Display(Name = "مشتری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerId { get; set; }

		[Display(Name = "اس کیو ال")]
		public int? SqlVersionId { get; set; }

		#region Relations

		[Display(Name = "نوع سرور")]
		public virtual ServerType ServerType { get; set; }

		[Display(Name = "مشتری")]
		public virtual Customer Customer { get; set; }

		[Display(Name = "سیستم عامل")]
		public virtual Os Os { get; set; }

		[Display(Name = "اس کیو ال")]
		public virtual SqlVersion SqlVersion { get; set; }

		[Display(Name = "توضیحات")]
		public ICollection<Comment> Comments { get; set; }
		#endregion


	}
}
