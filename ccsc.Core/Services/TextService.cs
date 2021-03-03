using ccsc.Core.Services.Interfaces;

namespace ccsc.Core.Services
{
	public class TextService : ITextService
	{
		public bool IsDuplicate(string str1, string str2)
		{
			bool isDuplicate = str1 == str2;

			return isDuplicate;

		}
	}
}
