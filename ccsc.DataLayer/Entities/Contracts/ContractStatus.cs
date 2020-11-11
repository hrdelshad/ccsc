using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Contracts
{
	public class ContractStatus
	{
		[Key]
		public int ContractStatusId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "فعال")]
		public bool IsOk { get; set; }
	}
}