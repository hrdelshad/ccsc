using ccsc.Core.DTOs;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Tutorials;

namespace ccsc.Core.Services
{
	public class ChangeSetService : IChangeSetService
	{
		private CcscContext _context;
		private ISubSystemService _subSystemService;
		private IUserTypeService _userTypeService;

		public ChangeSetService(CcscContext context, IUserTypeService userTypeService, ISubSystemService subSystemService)
		{
			_context = context;
			_userTypeService = userTypeService;
			_subSystemService = subSystemService;
		}

		public async Task UpdateAsync(ChangeSet input, List<int> subSystemIds, List<int> userTypeIds)
		{
			input.SubSystems = await _subSystemService.GetSubSystemsByIds(subSystemIds);
			input.UserTypes = await _userTypeService.GetUserTypesByIds(userTypeIds);

			_context.Update(input);
			await _context.SaveChangesAsync();
		}

		public IQueryable<ChangeSet> GetChangeSets() 
		{
			var result = _context.ChangeSets
				.Include(c => c.AppUser)
				.Include(c => c.ChangeType)
				.Include(e=>e.Video);
			return result;
		}

		public void AddChangeSet(ChangeSet newChangeSet)
		{
			_context.AddRange(
				new ChangeSet
				{
					ChangeSetId = newChangeSet.ChangeSetId,
					AppUserId = newChangeSet.AppUserId,
					Date = newChangeSet.Date,
					Comment = newChangeSet.Comment
				}
			);
			_context.SaveChanges();
		}

		public void AddChangeSet(ChangeSet newChangeSet, List<int> subSystemIds, List<int> userTypeIds)
		{
			_context.AddRange(
				new ChangeSet
				{
					ChangeSetId = newChangeSet.ChangeSetId,
					AppUserId = newChangeSet.AppUserId
					//SubSystems = GetSubSystemsByIds(subSystemIds),
					//UserTypes = GetUserTypesByIds(userTypeIds)
				}
			);
			_context.SaveChanges();
		}

		public void AddChangeSetFromTfs(TfsChangeSetViewModel tfsChangeSet)
		{
			_context.AddRange(
				new ChangeSet
				{
					ChangeSetId = tfsChangeSet.ChangeSetId,
					AppUserId = GetAppUserId(tfsChangeSet.Author.DisplayName),
					Date = tfsChangeSet.CreatedDate,
					Comment = tfsChangeSet.Comment
				}
			);
			_context.SaveChanges();
		}

		public bool ChangeSetExists(int changeSetId) => _context.ChangeSets.Any(e => e.ChangeSetId == changeSetId);

		public int GetAppUserId(string displayName)
		{
			var userList = _context.AppUsers.ToList();
			var user = userList.FirstOrDefault(item => SimplifyString(item.DisplayName) == SimplifyString(displayName));
			if(user == null)
			{
				return 0;
			}
			else
			{
				return user.AppUserId;
			}
		}

		public async Task RemoveRelatedAsync(ChangeSet changeSet)
		{

			var subSystems = GetSubSystemsOfChangeSet(changeSet.ChangeSetId);
			var userTypes = GetUserTypesForChangeSet(changeSet.ChangeSetId);

			if (subSystems.Any())
			{
				foreach (var ss in subSystems)
				{
					changeSet.SubSystems.Remove(ss);
					_context.Update(changeSet);
					await _context.SaveChangesAsync();
				}
			}

			if (userTypes.Any())
			{
				foreach (var ut in userTypes)
				{
					changeSet.UserTypes.Remove(ut);
					_context.Update(changeSet);
					await _context.SaveChangesAsync();
				}
			}
		}


		public List<SubSystem> GetSubSystemsOfChangeSet(int id)
		{
			List<SubSystem> changeSetSubSystems = new List<SubSystem>();
			changeSetSubSystems = _context.SubSystems
				.Include(s => s.ChangeSets)
				.Where(s => s.ChangeSets.Any(v => v.ChangeSetId == id))
				.ToList();

			return changeSetSubSystems;
		}

		public List<UserType> GetUserTypesForChangeSet(int id)
		{
			List<UserType> changeSetUserTypes = new List<UserType>();
			changeSetUserTypes = _context.UserTypes
				.Include(u => u.ChangeSets)
				.Where(u => u.ChangeSets.Any(v => v.ChangeSetId == id))
				.ToList();

			return changeSetUserTypes;
		}

		private string SimplifyString(string input)
		{
			return input.ToLower().Replace(" ", "").Replace("‌", "");
		}
	}
}
