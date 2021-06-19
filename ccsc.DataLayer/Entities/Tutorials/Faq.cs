using System.Collections.Generic;
using ccsc.DataLayer.Entities.ChangeSets;
using System.ComponentModel.DataAnnotations;
using ccsc.DataLayer.Entities.Common;
using ccsc.DataLayer.Entities.Customers;

namespace ccsc.DataLayer.Entities.Tutorials
{
	[Display(Name = "پرسش های پر تکرار")]
	public class Faq : BaseEntity
	{
		private const string DisplayName = "پرسش های پر تکرار";

		[Key]
		public int FaqId { get; set; }

		[Display(Name = "پرسش")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Question { get; set; }

		[Display(Name = "پاسخ")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(2000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Answer { get; set; }

		[Display(Name = "فعال")]
		public bool IsActive { get; set; }

		[Display(Name = "انتشار")]
		public bool Publish { get; set; }


		[Display(Name = "ورژن")]
		public int? Version { get; set; }

		#region Relations

		[Display(Name = "کد دانشگاه")]
		public int? UniversityId { get; set; }

		[Display(Name = "کد مشتری مرتبط")]
		public int? CustomerId { get; set; }

		[Display(Name = "مشتری مرتبط")]
		public Customer Customer { get; set; }

		[Display(Name = "کد ویدیو مرتبط")]
		public int? VideoId { get; set; }

		[Display(Name = "ویدیو مرتبط")]
		public Video Video { get; set; }


		[Display(Name = "مخاطبان")]
		public ICollection<UserType> UserTypes { get; set; }

		[Display(Name = "سامانه(ها)")]
		public ICollection<SubSystem> SubSystems { get; set; }
		#endregion

		public string ClassName {
			get { return DisplayName; }
		}
	}
}