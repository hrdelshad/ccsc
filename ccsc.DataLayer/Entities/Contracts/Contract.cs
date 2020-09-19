using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using ccsc.DataLayer.Entities.Courses;
using ccsc.DataLayer.Entities.Customers;
using ccsc.DataLayer.Entities.Products;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ccsc.DataLayer.Entities.Contracts
{
	public class Contract
	{
		public Contract()
		{
			
		}

		[Key]
		public int ContractId { get; set; }

		[Display(Name = "مشتری")]
		public int CustomerId { get; set; }

		[Display(Name = "تاریخ شروع قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public DateTime StartDate { get; set; }

		[Display(Name = "مدت قرارداد(ماه)")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int Duration { get; set; }

		[Display(Name = "مبلغ")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public decimal Amount { get; set; }

		[Display(Name = "وضعیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ContractStatusId { get; set; }

		[Display(Name = "نامحدود")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool UnLimited { get; set; }

		//[Display(Name = "محصول")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		//public int ProductId { get; set; }


		#region Relations

		[Display(Name = "مشتری")]
		public virtual Customer Customer { get; set; }

		[Display(Name = "محصولات")]
		public virtual List<Product> Products { get; set; }

		[Display(Name = "رشته ها")]
		public virtual List<Course> Courses { get; set; }

		#endregion
	}
}
