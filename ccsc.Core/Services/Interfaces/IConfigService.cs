using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Common;

namespace ccsc.Core.Services.Interfaces
{
	public interface IConfigService
	{
		int AddFaq(Config config);

		Task<Config> GetConfigByKey(string key);

		string GetConfigValue(string key);
		string GetConfigDescription(string key);

		IQueryable<Config> GetAllConfigs();
	}
}