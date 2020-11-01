using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Products
{
	public class ChangeType
	{
		[Key]
		public int ChangeTypeId { get; set; }

		[Display(Name = "نوع تغییر")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }
	}
}
