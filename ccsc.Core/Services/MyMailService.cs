using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Entities.Messages;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Threading.Tasks;


namespace ccsc.Core.Services
{
	public class MyMailService : IMyMailService
	{
		private readonly MailSettings _mailSettings;
		public MyMailService(IOptions<MailSettings> mailSettings)
		{
			_mailSettings = mailSettings.Value;
		}


		public async Task SendEmailAsync(MailRequest mailRequest)
		{
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
			email.Subject = mailRequest.Subject;
			var builder = new BodyBuilder();
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			using var smtp = new SmtpClient();
			smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}

		public async Task SendWelcomeEmailAsync(WelcomeRequest request)
		{
			string filePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html";
			StreamReader str = new StreamReader(filePath);
			string mailText = str.ReadToEnd();
			str.Close();
			mailText = mailText.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail);
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			email.To.Add(MailboxAddress.Parse(request.ToEmail));
			email.Subject = $"Welcome {request.UserName}";
			var builder = new BodyBuilder();
			builder.HtmlBody = mailText;
			email.Body = builder.ToMessageBody();
			using var smtp = new SmtpClient();
			smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}

		public async Task ParsEmailAsync(ParsRequest parsRequest)
		{
			// Load a MimeMessage from a stream
			var parser = new MimeParser(Stream.Null, MimeFormat.Entity);
			var message = parser.ParseMessage();
		}
	}
}