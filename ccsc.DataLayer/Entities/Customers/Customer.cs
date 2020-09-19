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

		#region Relations

		[Display(Name = "نوع")]
		public virtual CustomerType CustomerType { get; set; }

		public List<Server> Servers { get; set; }

		#endregion

	}
}
