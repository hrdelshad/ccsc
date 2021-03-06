﻿using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ccsc.DataLayer.Entities.Common;
using ccsc.DataLayer.Entities.Courses;

namespace ccsc.DataLayer.Entities.Contracts
{
	[Display(Name = "قرارداد")]
	public class Contract
	{
		[Key]
		public int ContractId { get; set; }

		[Display(Name = "عنوان قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "شماره قرارداد")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string ContractNo { get; set; }

		[Display(Name = "تاریخ شروع قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.Date)]
		//[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }

		[Display(Name = "مدت قرارداد(ماه)")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int Duration { get; set; }

		[Display(Name = "مبلغ")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[Column(TypeName = "decimal(18, 0)")]
		[DisplayFormat(DataFormatString = "{0:n}", ApplyFormatInEditMode = false)]
		//[DataType(DataType.Currency)]
		public decimal Amount { get; set; }

		[Display(Name = "نامحدود")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool UnLimited { get; set; }

		[Display(Name = "توضیحات")]
		public string Description { get; set; }


		#region Relations

		[Display(Name = "وضعیت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ContractStatusId { get; set; }

		[Display(Name = "وضعیت")]
		public ContractStatus ContractStatus { get; set; }

		[Display(Name = "مشتری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CustomerId { get; set; }

		[Display(Name = "مشتری")]
		public Customer Customer { get; set; }

		[Display(Name = "محصولات")]
		public ICollection<SubSystem> SubSystems { get; set; }

		[Display(Name = "محصولات")]
		public ICollection<Course> Courses { get; set; }

		#endregion
	}
}
