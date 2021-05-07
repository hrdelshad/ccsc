using System;
using System.ComponentModel.DataAnnotations;

namespace ccsc.DataLayer.Entities.Common
{
	public class BaseEntity
	{
		//[Key]
		//public long Id { get; set; }
		public bool IsDelete { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }
	}
}
