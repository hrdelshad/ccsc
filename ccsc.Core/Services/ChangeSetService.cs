using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;

namespace ccsc.Core.Services
{
	public class ChangeSetService : IChangeSetService
	{
		private CcscContext _context;
		public bool ChangeSetExists(int changeSetId)
		{
			return _context.ChangeSets.Any(e => e.ChangeSetId == changeSetId);
		}

		public int GetAppUserId(string displayName)
		{
			return _context.AppUsers.FirstOrDefault(u => u.DisplayName == displayName).AppUserId;
		}
	}
}
