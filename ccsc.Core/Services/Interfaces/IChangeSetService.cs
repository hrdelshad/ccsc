using ccsc.Core.DTOs;
using ccsc.DataLayer.Entities.ChangeSets;
using System.Collections.Generic;

namespace ccsc.Core.Services.Interfaces
{
	public interface IChangeSetService
	{
		bool ChangeSetExists(int changeSetId);
		int GetAppUserId(string displayName);

		void AddChangeSetFromTfs(TfsChangeSetViewModel tfsChangeSet);
		void AddChangeSet(ChangeSet newChangeSet);
		void AddChangeSet(ChangeSet newChangeSet, List<int> subSystemIds, List<int> userTypeIds);
	}
}