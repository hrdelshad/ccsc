using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Contracts;

namespace ccsc.DataLayer.Entities.Courses
{
	public class Course
	{
		[Key]
		public Guid CourseId { get; set; }

		[Display(Name = "عنوان رشته")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "مقطع")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public Guid CourseLevelId { get; set; }

		public string CourseCode { get; set; }

		public bool IsActive { get; set; }


		#region Relations
		[Display(Name = "مقطع")]
		public CourseLevel CourseLevel { get; set; }
		
		[Display(Name = "قرارداد")]
		public ICollection<Contract> Contracts { get; set; }

		#endregion
	}
}
