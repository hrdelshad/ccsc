using ccsc.DataLayer.Entities.Contacts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ccsc.Core.Services.Interfaces
{
	public interface ICustomerService
	{
		string GetVersion(string url);
		string TabibVersion(string url);

		bool CustomerExists(int customerId);

		List<SelectListItem> GetCustomerListItems();
		List<SelectListItem> GetContactOfCustomerListItems(int customerId);
		List<SelectListItem> GetContactOfCustomerListItems(int customerId, bool option);
		List<SelectListItem> GetContactListItems();

		List<Contact> GetContactsOfCustomer();
		List<Contact> GetContactsOfCustomer(int customerId);

	}

	
}