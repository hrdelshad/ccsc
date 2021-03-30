namespace ccsc.Core.Services.Interfaces
{
	public interface ISmsService
	{
		decimal GetSMSCredit(string sMSUser, string sMSPass);
		void SendSMS(string message, string[] to);
	}
}