using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Courses
{
	public class Course
	{
		[Key]
		public int CourseId { get; set; }

		[Display(Name = "عنوان رشته")][Required(ErrorMessage = "لطفا {0} را وارد کنید")][MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "مقطع")][Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CourseLevelId { get; set; }

		#region Relations
		[Display(Name = "مقطع")]
		public virtual CourseLevel CourseLevel { get; set; }

		#endregion
	}
}
