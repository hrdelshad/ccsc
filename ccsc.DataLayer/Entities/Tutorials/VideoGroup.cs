using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.Tutorials
{
	public class VideoGroup
	{
		[Key]
		public int VideoGroupId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "سرگروه")]
		public int? ParentId { get; set; }

		[ForeignKey("ParentId")]
		public VideoGroup VideoGroups { get; set; }


	}
}