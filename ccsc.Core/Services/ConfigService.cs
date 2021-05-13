using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Core.Services
{
	public class ConfigService : IConfigService
	{
		private CcscContext _context;

		public ConfigService(CcscContext context)
		{
			_context = context;
		}


		public int AddFaq(Config config)
		{ 
			 _context.Configs.Add(config);
			 _context.SaveChanges();
			 return config.Id;
		}

		public async Task<Config> GetConfigByKey(string key)
		{
			var res = await _context.Configs.Where(c => c.Key == key).FirstOrDefaultAsync();
			return res;
		}

		public IQueryable<Config> GetAllConfigs()
		{
			var result = _context.Configs;
			return result;
		}

		public string GetConfigValue(string key)
		{
			if (_context.Configs != null) return _context.Configs.FirstOrDefault(c => c.Key == key).Value;
			return "";
		}

		public string GetConfigDescription(string key)
		{
			if (_context.Configs != null) return _context.Configs.FirstOrDefault(c => c.Key == key).Description;
			return "";
		}
	}
}