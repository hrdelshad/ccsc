using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Tutorials
{
	public class Audience
	{
		[Key]
		[Display(Name = "شناسه")]
		public int AudienceId { get; set; }


		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "توضیحات")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		#region Relations

		[Display(Name = "ویدیوهای مرتبط")]
		public virtual ICollection<Video> Videos { get; set; }

		#endregion
	}
}
