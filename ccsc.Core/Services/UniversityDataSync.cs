using ccsc.Core.Convertors;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ccsc.Core.Services
{
	public class UniversityDataSync
	{
		//public static void Run(object sender, ElapsedEventArgs e)
		//{
		//	var obj = new UniversityDataSync();
		//	using (var db = new CcscContext())

		//	{
		//		var universityList = db.Customers.ToList();
		//		var sb = new StringBuilder();
		//		foreach (var university in universityList)
		//		{
		//			//university.SMSCredit = null;

		//			try
		//			{
		//				var version = GetVersionFromApi(university.Url);
		//				if (university.IsActiveSms == true)
		//				{
		//					var smsCredit = GetSMSCredit(university.SMSUser, university.SMSPass);
		//					university.SMSCredit = smsCredit;
		//					university.SMSCreditCheckDate = DateTime.Now;
		//					if (
		//						(!university.SendSmsDate.HasValue || university.SendSmsDate.Value.AddDays(university.AfterXDay) < DateTime.Now) &&
		//						smsCredit < university.MinSMSCredit
		//					)
		//					{
		//						//sb.Append(string.Format("موجودی {0} کمتر از {1} است ", university.Title, university.SMSCredit));
		//						sb.Append(" موجودی ");
		//						sb.Append(university.Title);
		//						sb.Append(" ");
		//						sb.Append(university.SMSCredit);
		//						sb.Append(" ریال است");
		//						sb.Append("\n");
		//						university.SendSmsDate = DateTime.Now;
		//					}
		//				}
		//				university.Version = version;
		//				university.VersionCheckDate = DateTime.Now;
		//				db.SaveChanges();
		//			}
		//			catch (Exception ex)
		//			{

		//			}
		//		}

		//		//SendSMS(sb.ToString(), new[] { "9125959167", "9122259893" });


		//	}
		//}

		public string TabibVersion(string url)
		{
			throw new NotImplementedException();
		}

		private string GetVersionFromApi(string universityUrl)
		{
			universityUrl = TextFixer.Url(universityUrl);

			var client = new HttpClient();
			//var uri = CreateRequestUri(universityUrl, "api/Tabib/Version");
			client.BaseAddress = new Uri(universityUrl);
			try
			{

				var response = client.GetAsync("api/Tabib/Version").Result;

				//response.EnsureSuccessStatusCode();
				if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					return GetVersionFromMainPage(universityUrl);
				}

				var version = response.Content.ReadAsStringAsync().Result;
				return version.Replace("\"", "");
			}
			catch (Exception ex)
			{
				return "Not Responding";
			}

		}
		public string GetVersionFromMainPage(string universityUrl)
		{
			universityUrl = TextFixer.Url(universityUrl);

			var client = new HttpClient();
			client.BaseAddress = new Uri(universityUrl);
			var response = client.GetAsync("Security/Accounts/Login").Result;

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var htmlBody = response.Content.ReadAsStringAsync().Result;
				var reg = new Regex(@"<span>version:(.*?)<\/span>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
				var matches = reg.Matches(htmlBody);
				var version = matches.FirstOrDefault();
				if (version == null)
				{
					throw new ApplicationException("Version Not Found in Login Page");
				}
				return version.Groups[1].Value.ToString().Trim();
			}

			throw new ApplicationException("Error in Load Page");
		}
	}
}
