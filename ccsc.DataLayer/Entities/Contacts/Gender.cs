using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ccsc.DataLayer.Entities.Contacts
{
	public class Gender
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int GenderId { get; set; }

		[Display(Name = "جنسیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
