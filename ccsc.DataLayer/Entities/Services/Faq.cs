using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Products;
using ccsc.DataLayer.Entities.Tutorials;

namespace ccsc.DataLayer.Entities.Services
{
	public class Faq
	{
		[Key]
		public int FaqId { get; set; }

		[Display(Name = "پرسش")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Question { get; set; }

		[Display(Name = "پاسخ")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(2000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Answer { get; set; }

		#region Relations

		[Display(Name = "کد مخاطب")]
		public int? AudienceId { get; set; }

		[Display(Name = "مخاطب")]
		public Audience Audience { get; set; }


		[Display(Name = "کد محصول مرتبط")]
		public int? ProductId { get; set; }

		[Display(Name = "محصول مرتبط")]
		public Product Product { get; set; }


		[Display(Name = "کد ویدیو مرتبط")]
		public int? VideoId { get; set; }

		[Display(Name = "ویدیو مرتبط")]
		public Video Video { get; set; }

		#endregion
	}
}