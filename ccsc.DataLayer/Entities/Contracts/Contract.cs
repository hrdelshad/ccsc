using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ccsc.DataLayer.Entities.Customers;

namespace ccsc.DataLayer.Entities.Contracts
{
	[Display(Name = "قرارداد")]
	public class Contract
	{
		public Contract()
		{

		}

		[Key]
		public int ContractId { get; set; }

		[Display(Name = "عنوان قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }


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
		[Column(TypeName = "decimal(18, 0)")]
		public decimal Amount { get; set; }

		[Display(Name = "وضعیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ContractStatusId { get; set; }

		[Display(Name = "نامحدود")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool UnLimited { get; set; }


		#region Relations

		[Display(Name = "مشتری")]
		public Customer Customer { get; set; }

		#endregion
	}
}
