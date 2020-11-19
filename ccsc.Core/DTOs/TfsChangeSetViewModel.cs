using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.Core.DTOs
{
	public class TfsChangeSetViewModel
	{

		public int ChangeSetId { get; set; }
		public string Url { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedDate { get; set; }

		public Guid Id { get; set; }

		[ForeignKey("Id")]
		public AuthorViewModel Author { get; set; }


	}
}
