using System.Collections.Generic;
using ccsc.DataLayer.Entities.Customers;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Common;

namespace ccsc.DataLayer.Entities.Contacts
{
	[Display(Name = "قرارداد")]
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
		public string LastName { get; set; }

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
		//[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(15, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Phone { get; set; }

		//[Display(Name = "جنسیت")]
		//public int GenderId { get; set; }

		[Display(Name = "عنوان")]
		public int SalutationId { get; set; }

		#region Relations

		[Display(Name = "سازمان")]
		public virtual Customer Customer { get; set; }

		[Display(Name = "پست سازمانی")]
		public virtual Post Post { get; set; }

		//[Display(Name = "جنسیت")]
		//public Gender Gender { get; set; }

		[Display(Name = "عنوان")]
		public virtual Salutation Salutation { get; set; }

		[Display(Name = "توضیحات")]
		public ICollection<Comment> Comments { get; set; }
		#endregion


	}
}
