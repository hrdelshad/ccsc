using System.Collections.Generic;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Tutorials
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

		[Display(Name = "فعال؟")]
		public bool IsActive { get; set; }

		#region Relations

		[Display(Name = "کد ویدیو مرتبط")]
		public int? VideoId { get; set; }

		[Display(Name = "ویدیو مرتبط")]
		public Video Video { get; set; }


		[Display(Name = "مخاطبان")]
		public ICollection<UserType> UserTypes { get; set; }

		[Display(Name = "سامانه(ها)")]
		public ICollection<SubSystem> SubSystems { get; set; }
		#endregion
	}
}