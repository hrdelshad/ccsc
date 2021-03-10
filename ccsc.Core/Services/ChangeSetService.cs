using ccsc.Core.DTOs;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using System.Collections.Generic;
using System.Linq;

namespace ccsc.Core.Services
{
	public class ChangeSetService : IChangeSetService
	{
		private CcscContext _context;

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
			var appUserId = _context.AppUsers.Where(u => u.DisplayName == displayName).FirstOrDefault().AppUserId;
			return appUserId;
		}
	}
}
