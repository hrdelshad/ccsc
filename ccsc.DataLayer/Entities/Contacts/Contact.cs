using System;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Customers;

namespace ccsc.DataLayer.Entities.Contacts
{
	public class Contact
	{
		public Contact()
		{

		}

		[Key]
		public int ContactId { get; set; }

		[Display(Name = "نام")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string FirstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string LasName { get; set; }

		[Display(Name = "سازمان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerId { get; set; }

		[Display(Name = "پست سازمانی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int PostId { get; set; }

		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Email { get; set; }


		[Display(Name = "موبایل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(15, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Mobile { get; set; }


		[Display(Name = "تلفن")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(15, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Phone { get; set; }


		#region Relations

		[Display(Name = "سازمان")]
		public Customer Customer { get; set; }

		[Display(Name = "پست سازمانی")]
		public Post Post { get; set; }


		#endregion


	}
}
