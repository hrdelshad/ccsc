using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Customers
{
	public class CustomerStatus
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CustomerStatusId { get; set; }

		[Display(Name = "وضعیت مشتری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "فعال / غیر‌فعال")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool IsActive { get; set; }
	}
}