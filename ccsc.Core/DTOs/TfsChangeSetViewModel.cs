using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccsc.Core.DTOs
{
	public class TfsChangeSetViewModel
	{

		public int changesetId { get; set; }
		public string url { get; set; }
		public string comment { get; set; }
		public DateTime createdDate { get; set; }

		public Guid id { get; set; }

		[ForeignKey("id")]
		public AuthorViewModel Author { get; set; }


	}
}
