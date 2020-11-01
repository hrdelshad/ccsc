using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Contracts
{
	public class ContractType
	{
		public ContractType()
		{
			
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ContractTypeId { get; set; }

		[Display(Name = "نوع قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
