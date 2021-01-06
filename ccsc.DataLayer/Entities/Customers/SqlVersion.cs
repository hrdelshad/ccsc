using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Customers
{
	public class SqlVersion
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SqlVersionId { get; set; }

		[Display(Name = "اس کیو ال")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
