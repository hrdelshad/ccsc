using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.Core.DTOs
{
	public class AuthorViewModel
	{
		public Guid id { get; set; }
		public string displayName { get; set; }
		public string uniqueName { get; set; }
	}
}
