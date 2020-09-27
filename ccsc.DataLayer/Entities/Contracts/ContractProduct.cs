using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ccsc.DataLayer.Entities.Products;

namespace ccsc.DataLayer.Entities.Contracts
{
	public class ContractProduct
	{
		[Key]
		public int ContractProductId { get; set; }

		[Display(Name = "قرادداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ContractId { get; set; }

		[Display(Name = "محصول")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ProductId { get; set; }


		#region Relations

		[Display(Name = "قرارداد")]
		public virtual Contract Contract { get; set; }

		[Display(Name = "محصول")]
		public virtual Product Product { get; set; }


		#endregion
	}
}
