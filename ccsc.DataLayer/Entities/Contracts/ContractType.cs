﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ccsc.DataLayer.Entities.Contracts
{
	public class ContractType
	{
		public ContractType()
		{
			
		}

		[Key]
		public int ContractTypeId { get; set; }

		[Display(Name = "نوع قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
