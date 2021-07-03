using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Identity;

namespace ccsc.DataLayer.Entities.Common
{
	public class UseFulLink
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "آدرس")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Url { get; set; }

		[Display(Name = "توضیحات")]
		[MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		public User Owner { get; set; }

		public int? OwnerId { get; set; }

	}
}
