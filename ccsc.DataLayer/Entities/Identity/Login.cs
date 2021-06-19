﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.DataLayer.Entities.Identity
{
	public class Login
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
