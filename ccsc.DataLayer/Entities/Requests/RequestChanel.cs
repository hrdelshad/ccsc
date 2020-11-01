using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Requests
{
	public class RequestChanel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RequestChanelId { get; set; }

		[Display(Name = "کانال درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
