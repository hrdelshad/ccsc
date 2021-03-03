using ccsc.DataLayer.Entities.Messages;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Interfaces
{
	public interface IMyMailService
	{
		Task SendEmailAsync(MailRequest mailRequest);
		Task SendWelcomeEmailAsync(WelcomeRequest request);
		Task ParsEmailAsync(ParsRequest parsRequest);
	}
}