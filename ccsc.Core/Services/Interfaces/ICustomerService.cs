﻿using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;
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


		List<Contract> GetContractsOfCustomer(int customerId);
		List<SelectListItem> GetContractOfCustomerListItems(int customerId);
		List<SelectListItem> GetContractOfCustomerListItems(int customerId, bool option);

		bool HasUnSupportedContract(int customerId);

	}

	
}