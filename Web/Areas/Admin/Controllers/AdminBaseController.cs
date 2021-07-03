﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ccsc.Web.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class AdminBaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string WarningMessage = "WarningMessage";
		protected string InfoMessage = "InfoMessage";
		protected string ErrorMessage = "ErrorMessage";
	}
}
