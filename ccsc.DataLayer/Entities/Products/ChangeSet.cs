using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ccsc.DataLayer.Entities.Tutorials;
using ccsc.DataLayer.Entities.Users;

namespace ccsc.DataLayer.Entities.Products
{
	public class ChangeSet
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ChangeSetId { get; set; }

		[Display(Name = "کد کاربر")]
		public int AppUserId { get; set; }


		[Display(Name = "کاربر")]
		public AppUser AppUser { get; set; }


		[Display(Name = "تاریخ")]
		public DateTime Date { get; set; }


		[Display(Name = "توضیح فنی")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Comment { get; set; }

		[Display(Name = "عنوان")]
		[MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "شرح کامل")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		[Display(Name = "ورژن")]
		[MaxLength(30, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Version { get; set; }

		[Display(Name = "کد ویدیو مرتبط")]
		public int? VideoId { get; set; }

		[Display(Name = "ویدیو مرتبط")]
		public Video Video { get; set; }

		[Display(Name = "کد محصول مرتبط")]
		public int? ProductId { get; set; }

		[Display(Name = "محصول مرتبط")]
		public Product Product { get; set; }

		[Display(Name = "کد نوع تغییر")]
		public int? ChangeTypeId { get; set; }

		[Display(Name = "نوع تغییر")]
		public ChangeType ChangeType { get; set; }

		[Display(Name = "کد مخاطب")]
		public int? AudienceId { get; set; }

		[Display(Name = "مخاطب")]
		public Audience Audience { get; set; }

		[Display(Name = "منتشر شود")]
		public bool IsPublish { get; set; }

		public string Quarter { get; set; }


	}
}
