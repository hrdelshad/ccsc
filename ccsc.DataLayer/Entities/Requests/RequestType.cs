using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Requests
{
	public class RequestType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RequestTypeId { get; set; }

		[Display(Name = "نوع درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "باسخ از طریق")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public ReplyByEnum ReplyByEnum { get; set; }
	}

	public enum ReplyByEnum
	{
		[Display(Name = "سرویس")]
		Service = 1,

		[Display(Name = "کار")]
		Duty = 2
	}
}
