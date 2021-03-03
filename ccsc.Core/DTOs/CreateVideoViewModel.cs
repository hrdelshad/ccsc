using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccsc.Core.DTOs
{
	public class CreateVideoViewModel
	{
		//public int VideoId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(60, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "ویدیو")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		//[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public IFormFile VideoFile { get; set; }

		[Display(Name = "پوستر")]
		//[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public IFormFile PosterFile { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		[Display(Name = "انتشار")]
		public bool Publish { get; set; }

		#region Relations

		public List<SubSystem> SelectedSubSystems { get; set; }
		public List<UserType> SelectedUserType { get; set; }

		#endregion
	}
}
