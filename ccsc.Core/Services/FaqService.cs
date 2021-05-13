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
		private ISubSystemService _subSystemService;
		private IUserTypeService _userTypeService;

		public FaqService(CcscContext context, IUserTypeService userTypeService, ISubSystemService subSystemService)
		{
			_context = context;
			_userTypeService = userTypeService;
			_subSystemService = subSystemService;
		}

		public int AddFaq(Faq faq)
		{
			_context.Faqs.Add(faq);
			_context.SaveChanges();
			return faq.FaqId;
		}

		public async Task UpdateFaqAsync(Faq updatedFaq, List<int> subSystemIds, List<int> userTypeIds)
		{
			updatedFaq.SubSystems = await _subSystemService.GetSubSystemsByIds(subSystemIds);
			updatedFaq.UserTypes = await _userTypeService.GetUserTypesByIds(userTypeIds);

			_context.Update(updatedFaq);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveFaqRelatedAsync(Faq faq)
		{

			var subSystems = await _subSystemService.GetSubSystemsOfFaq(faq.FaqId);
			var userTypes = await _userTypeService.GetUserTypesForFaq(faq.FaqId);
			
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

		public async Task AddFaqAsync(Faq newFaq, List<int> subSystemIds, List<int> userTypeIds)
		{
			_context.AddRange(
				new Faq
				{
					Question = newFaq.Question,
					Answer = newFaq.Answer,
					IsActive = newFaq.IsActive,
					VideoId = newFaq.VideoId,
					SubSystems = await _subSystemService.GetSubSystemsByIds(subSystemIds),
					UserTypes = await _userTypeService.GetUserTypesByIds(userTypeIds)
				}
			);
			await _context.SaveChangesAsync();
		}

	}
}
