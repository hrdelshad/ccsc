using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ccsc.DataLayer.Entities.Customers
{
	public class Os
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int OsId { get; set; }

		[Display(Name = "سیستم عامل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
