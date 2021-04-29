using ccsc.Core.DTOs;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ccsc.Core.Services
{
	public class ChangeSetService : IChangeSetService
	{
		private CcscContext _context;

		public ChangeSetService(CcscContext context)
		{
			_context = context;
		}

		public IQueryable<ChangeSet> GetChangeSets() 
		{
			var result = _context.ChangeSets
				.Include(c => c.AppUser)
				.Include(c => c.ChangeType)
				.Include(c => c.Video);
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
			var user = userList.Where(item => SimplifyString(item.DisplayName) == SimplifyString(displayName)).FirstOrDefault();
			if(user == null)
			{
				return 0;
			}
			else
			{
				return user.AppUserId;
			}
		}

		private string SimplifyString(string input)
		{
			return input.ToLower().Replace(" ", "").Replace("‌", "");
		}
	}
}
