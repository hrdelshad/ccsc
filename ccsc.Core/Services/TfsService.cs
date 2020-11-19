using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ccsc.Core.DTOs;
using ccsc.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace ccsc.Core.Services
{
	public class TfsService : ITfsService
	{
		async Task<IQueryable<TfsChangeSetViewModel>> ITfsService.GetChangeSets()
		{
			string apiUrl = "https://residency.visualstudio.com/residents/_apis/tfvc/changesets?api-version=6.0";

			try
			{
				var personalaccesstoken = "ycdd5i5fnweercq7ruhjn6llw53fvybmuh4urpcptuzezwu5ordq";

				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
						Convert.ToBase64String(
							System.Text.Encoding.ASCII.GetBytes(
								string.Format("{0}:{1}", "", personalaccesstoken))));

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
			catch (Exception)
			{
				// ReSharper disable once PossibleNullReferenceException
				throw null;
			}
		}
	}

}