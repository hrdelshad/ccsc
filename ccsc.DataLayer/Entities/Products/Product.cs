using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ccsc.DataLayer.Entities.Contracts;
using ccsc.DataLayer.Entities.Tutorials;

namespace ccsc.DataLayer.Entities.Products
{
	public class Product
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ProductId { get; set; }

		[Display(Name = "محصول")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }


		[Display(Name = "فعال")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool IsActive { get; set; } = true;


		#region Relations

		[Display(Name = "ویدیو(ها)")]
		public ICollection<Video> Videos { get; set; }

		[Display(Name = "قرارداد(ها)")]
		public ICollection<Contract> Contracts { get; set; }

		#endregion

	}
}