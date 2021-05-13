using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Core.Services
{
	public class SubSystemService : ISubSystemService
	{
		private CcscContext _context;

		public SubSystemService(CcscContext context)
		{
			_context = context;
		}

		public async Task<List<SubSystem>> GetSubSystems()
		{
			var res = await _context.SubSystems.ToListAsync();
			return res;
		}

		public async Task<List<SubSystem>> GetSubSystemsByIds(List<int> subSystemIds)
		{
			List<SubSystem> subSystems = new List<SubSystem>();
			foreach (int id in subSystemIds)
			{
				var ss = await GetSubSystemById(id);
				subSystems.Add(ss);
			}

			return subSystems;
		}

		public List<SubSystem> GetSubSystemsForChangeSet(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<SubSystem> GetSubSystemById(int id)
		{
			return await _context.SubSystems.FindAsync(id);
		}

		public async Task<List<SubSystem>> GetSubSystemsOfFaq(int id)
		{
			List<SubSystem> faqSubSystems = new List<SubSystem>();
			if (_context != null)
				faqSubSystems = await _context.SubSystems
					.Include(s => s.Faqs)
					.Where(s => s.Faqs.Any(v => v.FaqId == id))
					.ToListAsync();

			return faqSubSystems;
		}

		public async Task<List<SubSystem>> GetCurrentSubSystems(string entity, int id)
		{
			if (entity != null)
				switch (entity.ToLower())
				{
					case "changeset":
						return await _context.SubSystems
							.Include(s => s.ChangeSets)
							.Where(s => s.ChangeSets.Any(e => e.ChangeSetId == id))
							.ToListAsync();

					case "faq":
						return await _context.SubSystems
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
