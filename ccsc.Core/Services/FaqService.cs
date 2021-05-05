using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Tutorials;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Core.Services
{
	public class FaqService : IFaqService
	{
		private CcscContext _context;

		public FaqService(CcscContext context)
		{
			_context = context;
		}

		public int AddFaq(Faq faq)
		{
			_context.Faqs.Add(faq);
			_context.SaveChanges();
			return faq.FaqId;
		}

		public async Task UpdateFaqAsync(Faq updatedFaq, List<int> subSystemIds, List<int> userTypeIds)
		{
			//updatedFaq.SubSystems = null;
			//updatedFaq.UserTypes = null;
			updatedFaq.SubSystems = GetSubSystemsByIds(subSystemIds);
			updatedFaq.UserTypes = GetUserTypesByIds(userTypeIds);

			_context.Update(updatedFaq);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveFaqRelatedAsync(Faq faq)
		{

			var subSystems = GetSubSystemsOfFaq(faq.FaqId);
			var userTypes = GetUserTypesForFaq(faq.FaqId);
			
			if (subSystems.Any())
			{
				foreach (var ss in subSystems)
				{
					faq.SubSystems.Remove(ss);
					_context.Update(faq);
					await _context.SaveChangesAsync();
				}
			}

			if (userTypes.Any())
			{
				foreach (var ut in userTypes)
				{
					faq.UserTypes.Remove(ut);
					_context.Update(faq);
					await _context.SaveChangesAsync();
				}
			}
		}

		public void RemoveSubSystemsFromFaq(int faqId, List<int> subSystemIds)
		{
			foreach (int subSystemId in subSystemIds)
			{
				_context.Faqs.Find(faqId).SubSystems.Remove(_context.SubSystems.Find(subSystemId));
			}
			_context.SaveChanges();
		}

		public List<SubSystem> GetSubSystems()
		{
			return _context.SubSystems.ToList();
		}

		public List<SubSystem> GetSubSystemsByIds(List<int> subSystemIds)
		{
			List<SubSystem> subSystems = new List<SubSystem>();
			foreach (int id in subSystemIds)
			{
				var ss = GetSubSystemById(id);
				subSystems.Add(ss);
			}

			return subSystems;
		}

		public List<SubSystem> GetSubSystemsOfFaq(int id)
		{
			List<SubSystem> faqSubSystems = new List<SubSystem>();
			faqSubSystems = _context.SubSystems
				.Include(s => s.Faqs)
				.Where(s => s.Faqs.Any(v => v.FaqId == id))
				.ToList();

			return faqSubSystems;
		}

		public SubSystem GetSubSystemById(int id)
		{
			return _context.SubSystems.Find(id);
		}

		public List<UserType> GetUserTypes()
		{
			return _context.UserTypes.ToList();
		}

		public List<UserType> GetUserTypesByIds(List<int> userTypeIds)
		{
			List<UserType> userTypes = new List<UserType>();
			foreach (int id in userTypeIds)
			{
				var ut = GetUserTypeById(id);
				userTypes.Add(ut);
			}

			return userTypes;
		}

		public List<UserType> GetUserTypesForFaq(int id)
		{
			List<UserType> faqUserTypes = new List<UserType>();
			faqUserTypes = _context.UserTypes
				.Include(u => u.Faqs)
				.Where(u => u.Faqs.Any(v => v.FaqId == id))
				.ToList();

			return faqUserTypes;
		}

		public UserType GetUserTypeById(int id)
		{
			return _context.UserTypes.Find(id);
		}

		public void AddFaq(Faq newFaq, List<int> subSystemIds, List<int> userTypeIds)
		{
			_context.AddRange(
				new Faq
				{
					Question = newFaq.Question,
					Answer = newFaq.Answer,
					IsActive = newFaq.IsActive,
					VideoId = newFaq.VideoId,
					SubSystems = GetSubSystemsByIds(subSystemIds),
					UserTypes = GetUserTypesByIds(userTypeIds)
				}
			);
			_context.SaveChanges();
		}

	}
}
