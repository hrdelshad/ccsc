using System;
using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Customers;
using ccsc.DataLayer.Entities.Tutorials;

namespace ccsc.Core.Services.Interfaces
{
	public interface ICustomerService
	{
		string GetVersion(string url);
		string TabibVersion(string url);

		DateTime VersionDate(string url);
		bool CustomerExists(int customerId);

		Task<List<Customer>> GetCustomers();

		List<SelectListItem> GetCustomerListItems();
		List<SelectListItem> GetContactOfCustomerListItems(int customerId);
		List<SelectListItem> GetContactOfCustomerListItems(int customerId, bool option);
		List<SelectListItem> GetContactOfCustomerListItemsPlus(int customerId, bool option);
		List<SelectListItem> GetContactListItems();

		List<Contact> GetContactsOfCustomer();
		List<Contact> GetContactsOfCustomer(int customerId);


		List<Contract> GetContractsOfCustomer(int customerId);
		List<SelectListItem> GetContractOfCustomerListItems(int customerId);
		List<SelectListItem> GetContractOfCustomerListItems(int customerId, bool option);

		bool HasUnSupportedContract(int customerId);

		Task<Customer> GetCustomerById(int id);
		Task<List<Customer>> GetCustomersByIds(List<int> customerIds);
		Task<Customer> GetCustomerByUniversityId(int id);
		Task<int> GetUniversityIdByCustomerId(int id);
	}
}