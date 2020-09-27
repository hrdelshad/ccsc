﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ccsc.DataLayer.Entities.Courses;

namespace ccsc.DataLayer.Entities.Contracts
{
	public class ContractCours
	{
		[Key]
		public int ContractCoursId { get; set; }

		[Display(Name = "قرارداد")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ContractId { get; set; }

		[Display(Name = "رشته")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int CourseId { get; set; }


		#region Relations

		[Display(Name = "قرارداد")]
		public virtual Contract Contract { get; set; }

		[Display(Name = "رشته")]
		public virtual Course Course { get; set; }


		#endregion
	}
}
