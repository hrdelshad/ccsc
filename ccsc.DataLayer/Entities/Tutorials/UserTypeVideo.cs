using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.DataLayer.Entities.Tutorials
{
	public class UserTypeVideo
	{
		//[Key]
		//public int UserTypeVideoId { get; set; }
		public virtual int UserTypeId { get; set; }

		public virtual int VideoId { get; set; }
		public UserType UserType { get; set; }
		public Video Video { get; set; }
		//public DateTime GivenOn { get; set; }
	}
}
