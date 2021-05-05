#nullable enable
using ccsc.DataLayer.Entities.Tutorials;
using ccsc.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.ChangeSets
{
	public class ChangeSet
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ChangeSetId { get; set; }

		[Display(Name = "کد کاربر")]
		public int AppUserId { get; set; }


		[Display(Name = "کاربر")]
		public AppUser? AppUser { get; set; }


		[Display(Name = "تاریخ")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }


		[Display(Name = "توضیح فنی")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string? Comment { get; set; }

		[Display(Name = "عنوان")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string? Title { get; set; }

		[Display(Name = "شرح کامل")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string? Description { get; set; }

		[Display(Name = "ورژن")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string? Version { get; set; }


		[Display(Name = "انتشار")] 
		public bool IsPublish { get; set; }

		public string? Quarter { get; set; }

		#region Relations

		

		[Display(Name = "نوع تغییر")]
		public int? ChangeTypeId { get; set; }
		[Display(Name = "نوع تغییر")]
		public ChangeType? ChangeType { get; set; }


		[Display(Name = "ویدیو مرتبط")]
		public int? VideoId { get; set; }

		[Display(Name = "ویدیو مرتبط")]
		public Video? Video { get; set; }


		[Display(Name = "مخاطبان")]
		public ICollection<UserType> UserTypes { get; set; }

		[Display(Name = "سامانه(ها)")]
		public ICollection<SubSystem> SubSystems { get; set; }


		#endregion

	}
}
