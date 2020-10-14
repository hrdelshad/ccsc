using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ccsc.DataLayer.Entities.Users;

namespace ccsc.DataLayer.Entities.Products
{
	public class ChangeSet
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ChangeSetId { get; set; }

		[Display(Name = "کد کاربر")]
		public int UserId { get; set; }


		[Display(Name = "کاربر")]
		public User User { get; set; }


		[Display(Name = "تاریخ")]
		public DateTime Date { get; set; }


		[Display(Name = "توضیح فنی")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Comment { get; set; }


		[Display(Name = "شرح کامل")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		[Display(Name = "ورژن")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Version { get; set; }


	}
}
