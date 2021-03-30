using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Common.CommandLine;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Jobs
{
	[DisallowConcurrentExecution]
	public class CheckCustomerInfo : IJob
	{
		private ICustomerService _service;
		private ISmsService _smsService;
		CcscContext _context;
		public CheckCustomerInfo(ICustomerService service, ISmsService smsService, CcscContext context)
		{
			_service = service;
			_context = context;
			_smsService = smsService;
		}
		

		public Task Execute(IJobExecutionContext context)
		{
			{
				var sb = new StringBuilder();
				var ccscContext = _context.Customers.Include(c => c.CustomerType);
				foreach (Customer customer in ccscContext)
					try
					{
						var version = _service.GetVersion(customer.Url);
						if (customer.IsActiveSms == true)
						{
							var smsCredit = _smsService.GetSMSCredit(customer.SmsUser, customer.SmsPass);
							customer.SmsCredit = smsCredit;
							customer.SmsCreditCheckDate = DateTime.Now;
							if (
								(!customer.SendSmsDate.HasValue || 
								  customer.SendSmsDate.Value.AddDays(customer.AfterXDay) < DateTime.Now) &&
								  smsCredit < customer.MinSmsCredit
							)
							{
								//sb.Append(string.Format("موجودی {0} کمتر از {1} است ", university.Title, university.SMSCredit));
								//sb.Append(" موجودی ");
								sb.Append(customer.Title);
								sb.Append(" ");
								sb.Append(customer.SmsCredit.ToString("#,#"));
								sb.Append(" ریال");
								sb.Append("\n");
								customer.SendSmsDate = DateTime.Now;
							}
						}
						customer.Version = version;
						customer.VersionCheckDate = DateTime.Now;
						_context.Update(customer);

					}
					catch
					{
						// ignored
					}

				_context.SaveChangesAsync();
				_smsService.SendSMS(sb.ToString(), new[] { "9125959167" });
			}
			return Task.CompletedTask;
		}
	}
}
