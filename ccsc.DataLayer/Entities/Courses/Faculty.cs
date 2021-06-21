using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Courses
{
	public class Faculty
	{
		[Key]
		public Guid FacultyId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		#region Relations

		public ICollection<Group> Groups { get; set; }

		#endregion
	}
}