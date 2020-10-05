using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ccsc.DataLayer.Entities.Courses
{
	public class CourseLevel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CourseLevelId { get; set; }

		[Display(Name = "عنوان مقطع")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
