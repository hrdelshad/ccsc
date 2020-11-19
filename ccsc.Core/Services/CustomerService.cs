using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using ccsc.Core.Convertors;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;

namespace ccsc.Core.Services
{
	public class CustomerService : ICustomerService
	{
		CcscContext _context;

		public CustomerService(CcscContext context)
		{
			_context = context;
		}

		public bool CustomerExists(int id)
		{
			return _context.Customers.Any(e => e.CustomerId == id);
		}

		public string GetVersionAsync(string url)
		{
			throw new NotImplementedException();
		}

		public string GetVersion(string universityUrl)
		{
			universityUrl = TextFixer.Url(universityUrl);

			var client = new HttpClient();
			client.BaseAddress = new Uri(universityUrl);
			try
			{
				var response = client.GetAsync("api/Tabib/Version").Result;

				if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					return GetVersionFromMainPage(universityUrl);
				}

				else
				{
					return GetVersionFromApi(universityUrl);
				}
				var version = response.Content.ReadAsStringAsync().Result;
				return version.Replace("\"", "");
			}
			catch (Exception ex)
			{
				return "سرور در دسترس نیست.";
			}

		}

		public string GetVersionFromApi(string universityUrl)
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
				return "سرور در دسترس نیست.";
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

		public string TabibVersion(string url)
		{
			throw new NotImplementedException();
		}
	}
}
