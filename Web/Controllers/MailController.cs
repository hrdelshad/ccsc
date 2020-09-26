using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Entities.Messages;
using Microsoft.AspNetCore.Mvc;

namespace ccsc.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MailController : Controller
	{
		private readonly IMyMailService mailService;
		public MailController(IMyMailService mailService)
		{
			this.mailService = mailService;
		}
		[HttpPost("send")]
		public async Task<IActionResult> SendMail([FromForm] MailRequest request)
		{
			try
			{
				await mailService.SendEmailAsync(request);
				return Ok();
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		[HttpPost("welcome")]
		public async Task<IActionResult> SendWelcomeMail([FromForm] WelcomeRequest request)
		{
			try
			{
				await mailService.SendWelcomeEmailAsync(request);
				return Ok();
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
