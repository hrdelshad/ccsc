using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Customers
{
	public class CustomerType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CustomerTypeId { get; set; }

		[Display(Name = "نوع مشتری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
