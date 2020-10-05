using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ccsc.DataLayer.Entities.Requests
{
	public class RequestStatus
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RequestStatusId { get; set; }

		[Display(Name = "وضعیت درخواست")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {0} کارکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "فعال است؟")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public bool IsActive { get; set; }
	}
}
