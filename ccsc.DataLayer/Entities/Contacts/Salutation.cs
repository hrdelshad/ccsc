using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ccsc.DataLayer.Entities.Contacts
{
	public class Salutation
	{
		[Key]
		public int SalutationId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "جنسیت")]
		public int GenderId { get; set; }

		#region Relations

		public virtual Gender Gender { get; set; }

		#endregion
	}
}
