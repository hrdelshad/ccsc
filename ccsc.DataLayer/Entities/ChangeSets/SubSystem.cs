using ccsc.DataLayer.Entities.Contracts;
using ccsc.DataLayer.Entities.Tutorials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.DataLayer.Entities.ChangeSets
{
	public class SubSystem
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SubSystemId { get; set; }


		[Display(Name = "محصول")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Title { get; set; }


		[Display(Name = "فعال")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool IsActive { get; set; } = true;


		#region Relations

		[Display(Name = "ویدیو(ها)")]
		public ICollection<Video> Videos { get; set; }

		[Display(Name = "تغییرات")]
		public ICollection<ChangeSet> ChangeSets { get; set; }

		[Display(Name = "قرارداد(ها)")]
		public ICollection<Contract> Contracts { get; set; }

		[Display(Name = "سوالات")]
		public ICollection<Faq> Faqs { get; set; }

		#endregion

	}
}