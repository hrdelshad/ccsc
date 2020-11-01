using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ccsc.Core.Services
{
	public class SmsService
	{
		public decimal GetSMSCredit(string sMSUser, string sMSPass)
		{
			try
			{

				var client = new RestClient("http://ippanel.com/api/select");
				var request = new RestRequest(Method.POST);
				request.AddHeader("Cache-Control", "no-cache");
				request.AddHeader("Content-Type", "application/json");
				request.AddParameter("undefined", "{\"op\" : \"credit\",\"uname\" : \"" + sMSUser + "\",\"pass\":  \"" + sMSPass + "\"}", ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				var content = response.Content;
				var x = JToken.Parse(content)[1].Value<decimal>();
				return x;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}

		public static void SendSMS(string message, string[] to)
		{
			var messageObject = new
			{
				op = "send",
				uname = "targetsms",
				pass = "Enico2016",
				message = message,
				from = "100020400",
				to = to
			};
			string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(messageObject);

			var client = new RestClient("http://37.130.202.188/api/select");
			var request = new RestRequest(Method.POST);
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader("Content-Type", "application/json");

			request.AddParameter("undefined", jsonString, ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);
		}
	}
}
