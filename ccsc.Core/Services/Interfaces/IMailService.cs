﻿using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Messages;

namespace ccsc.Core.Services.Interfaces
{
	public interface IMailService
	{
		Task SendEmailAsync(MailRequest mailRequest);
		Task SendWelcomeEmailAsync(WelcomeRequest request);
		Task ParsEmailAsync(ParsRequest parsRequest);
	}
}