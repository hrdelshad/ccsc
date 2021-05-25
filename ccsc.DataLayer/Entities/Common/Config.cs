using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Common
{
	public class Config
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "شناسه")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Key { get; set; }

		[Display(Name = "مقدار")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Value { get; set; }

		[Display(Name = "توضیح")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(2000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
		public string Description { get; set; }

		public ConfigCategoryEnum Category { get; set; }

	}

	public enum ConfigCategoryEnum
	{
		[Display(Name = "عمومی")]
		General,

		[Display(Name = "سرویس‌ها")]
		Services,

		[Display(Name = "پیامک")]
		Sms,
	}
}