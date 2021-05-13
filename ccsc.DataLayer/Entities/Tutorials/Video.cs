using ccsc.DataLayer.Entities.ChangeSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Tutorials
{
	public class Video
	{
		[Key]
		public int VideoId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(60, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "مسیر")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Path { get; set; }

		[Display(Name = "مسیر پوستر")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string PosterPath { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		[Display(Name = "تاریخ انتشار")]
		[DataType(DataType.Date)]
		public DateTime? PublishedOn { get; set; }

		[Display(Name = "تاریخ بروزرسانی")]
		[DataType(DataType.Date)]
		public DateTime? ModifiedOn { get; set; }

		[Display(Name = "انتشار")]
		public bool Publish { get; set; }

		[Display(Name = "ورژن")]
		public int? Version { get; set; }

		#region Relations

		[Display(Name = "مخاطبان")]
		public ICollection<UserType> UserTypes { get; set; }

		[Display(Name = "سامانه(ها)")]
		public ICollection<SubSystem> SubSystems { get; set; }

		#endregion


	}
}
