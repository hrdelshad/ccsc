using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Core.Services
{
	public class UserTypeService : IUserTypeService
	{
		private readonly CcscContext _context;


		public UserTypeService(CcscContext context)
		{
			_context = context;
		}

		public async Task<List<UserType>> GetUserTypes()
		{
			var res = await _context.UserTypes.ToListAsync();
			return res;
		}

		public async Task<List<UserType>> GetUserTypesByIds(List<int> userTypeIds)
		{
			List<UserType> userTypes = new List<UserType>();
			foreach (int id in userTypeIds)
			{
				var ss = await GetUserTypeById(id);
				userTypes.Add(ss);
			}

			return userTypes;
		}

		public async Task<UserType> GetUserTypeById(int id)
		{
			return await _context.UserTypes.FindAsync(id);
		}

		public async Task<List<UserType>> GetUserTypesForFaq(int id)
		{
			List<UserType> faqUserTypes = new List<UserType>();
			if (_context != null)
				faqUserTypes = await _context.UserTypes
				.Include(u => u.Faqs)
				.Where(u => u.Faqs.Any(v => v.FaqId == id))
				.ToListAsync();

			return faqUserTypes;
		}

		public async Task<List<UserType>> GetCurrentUserTypes(string entity, int id)
		{
			if (entity != null)
				switch (entity.ToLower())
				{
					case "changeset":
						return await _context.UserTypes
							.Include(s => s.ChangeSets)
							.Where(s => s.ChangeSets.Any(e => e.ChangeSetId == id))
							.ToListAsync();

					case "faq":
						return await _context.UserTypes
							.Include(s => s.Faqs)
							.Where(s => s.Faqs.Any(e => e.FaqId == id))
							.ToListAsync();
					default:
						break;
				}

			return null;
		}
	}
}
