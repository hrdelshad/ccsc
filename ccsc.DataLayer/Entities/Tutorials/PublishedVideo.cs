using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ccsc.DataLayer.Entities.Products;

namespace ccsc.DataLayer.Entities.Tutorials
{
	public class PublishedVideo
	{
		[Key]
		public int PublishedVideoId { get; set; }


		[Display(Name = "ورژن")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Version { get; set; }

		[Display(Name = "ویدیو")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int VideoId { get; set; }

		[Display(Name = "سامانه")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ProductId { get; set; }

		[Display(Name = "ویدیو")]
		public Video Video { get; set; }

		[Display(Name = "سامانه")]
		public Product Product { get; set; }


	}
}
