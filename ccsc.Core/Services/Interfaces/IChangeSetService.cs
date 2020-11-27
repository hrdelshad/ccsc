namespace ccsc.Core.Services.Interfaces
{
	public interface IChangeSetService
	{
		bool ChangeSetExists(int changeSetId);
		int GetAppUserId(string displayName);
	}
}