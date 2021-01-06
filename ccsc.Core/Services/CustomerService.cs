using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using ccsc.Core.Convertors;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Contacts;
using Microsoft.AspNetCore.Mvc.Rendering;

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

		public List<SelectListItem> GetCustomerListItems()
		{
			return _context.Customers.Select(c => new SelectListItem()
			{
				Value = c.CustomerId.ToString(),
				Text = c.CustomerType.Title +" " + c.Title
			}).ToList();
		}

		public List<SelectListItem> GetContactOfCustomerListItems(int customerId)
		{
			return _context.Contacts.Where(c => c.CustomerId == customerId)
				.Select(c => new SelectListItem()
				{
					Value = c.ContactId.ToString(),
					Text = c.FirstName + " " + c.LastName
				}).ToList();
		}

		public List<SelectListItem> GetContactOfCustomerListItems(int customerId, bool option)
		{
			if (!option)
			{
				return GetContactOfCustomerListItems(customerId);

			}
			List<SelectListItem> listItems = new List<SelectListItem>()
			{
				new SelectListItem() {Text = "انتخاب کنید", Value = ""}
			};
			listItems.AddRange(GetContactOfCustomerListItems(customerId));
			return listItems;
		}
		public List<SelectListItem> GetContactListItems()
		{
			return _context.Contacts
				.Select(c => new SelectListItem()
				{
					Value = c.ContactId.ToString(),
					Text = c.FirstName + " " + c.LastName
				}).ToList();
		}

		public List<Contact> GetContactsOfCustomer()
		{
			return _context.Contacts.ToList();
		}

		public List<Contact> GetContactsOfCustomer(int customerId)
		{
			return _context.Contacts.Where(c => c.CustomerId == customerId).ToList();
		}

		public List<Contact> GetContactOfCustomer(int customerId)
		{
			return _context.Contacts.Where(c => c.CustomerId == customerId).ToList();
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
			}
			catch (Exception)
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
			catch (Exception)
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
				return version.Groups[1].Value.Trim();
			}

			throw new ApplicationException("Error in Load Page");
		}

		public string TabibVersion(string url)
		{
			throw new NotImplementedException();
		}
	}
}
