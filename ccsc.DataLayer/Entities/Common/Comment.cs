using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ccsc.DataLayer.Entities.Identity;

namespace ccsc.DataLayer.Entities.Common
{
	public class Comment
	{
		[Key]
		public Guid CommentId { get; set; }

		public DateTime DateTime { get; set; }

		public string Text { get; set; }

		public bool Publish { get; set; }

		public CommentTypeEnum CommentType { get; set; }


		[ForeignKey("User"), Column("Id")]
		public int UserId { get; set; }
		public User User { get; set; }

	}

	public enum CommentTypeEnum
	{
		[Display(Name = "شخصی")]
		Private,
		
		[Display(Name = "اشتراکی")]
		Share
	}
}
