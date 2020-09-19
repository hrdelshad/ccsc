using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Contacts
{
	public class Post
	{
		public Post()
		{
			
		}

		[Key]
		public int PostId { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }
	}
}
