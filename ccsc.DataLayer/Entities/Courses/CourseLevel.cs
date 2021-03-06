﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

		public int CourseCode { get; set; }
	}
}
