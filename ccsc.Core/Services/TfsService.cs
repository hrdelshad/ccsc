using ccsc.Core.DTOs;
using ccsc.Core.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ccsc.Core.Services
{
	public class TfsService : ITfsService
	{
		private readonly IConfigService _configService;

		public TfsService(IConfigService configService)
		{
			_configService = configService;
		}

		async Task<IQueryable<TfsChangeSetViewModel>> ITfsService.GetChangeSets()
		{
			string apiUrl = "https://residency.visualstudio.com/residents/_apis/tfvc/changesets?api-version=6.0";

			try
			{
				// برای ساخت توکن از این آدرس زیر استفاده کرد:
				// https://residency.visualstudio.com/_usersSettings/tokens
				
				var tfsToken = _configService.GetConfigValue("tfsToken");
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
						Convert.ToBase64String(
							System.Text.Encoding.ASCII.GetBytes(
								string.Format("{0}:{1}", "", tfsToken))));

					using (HttpResponseMessage response = client.GetAsync(apiUrl).Result)
					{
						response.EnsureSuccessStatusCode();
						var responseBody = await response.Content.ReadAsStringAsync();
						var replaceValue = "{\"count\":100,\"value\":";
						var result = responseBody.Replace(replaceValue, "").TrimEnd('}');
						var list = JsonConvert.DeserializeObject<List<TfsChangeSetViewModel>>(result);
						return list.AsQueryable();
					}
				}
			}
			catch (Exception e)
			{
				throw null;
			}
		}
	}

}