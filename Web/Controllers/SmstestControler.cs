using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sms;

namespace ccsc.Web.Controllers
{
	[Authorize]
	public class SmsTestController : Controller
	{
		public IActionResult Index()
		{
			var username = "targetsms";
			var password = "Enico2016";
			var fromNum = "100020400";
			string[] toNum = { "09125959167" };

			var patternCode = "119";

			DelSms.SendSMS("test", toNum, username, password, fromNum);
			return null;
		}
	
	}
}
