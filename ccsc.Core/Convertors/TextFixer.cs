using static System.String;

namespace ccsc.Core.Convertors
{
	public class TextFixer
	{
		public static string EmailAddress(string email)
		{
			return email.Trim().ToLower();
		}

		public static string Url(string url)
		{
			string fixUrl = url ?? "null";

			fixUrl = fixUrl.Trim();

			if (!fixUrl.EndsWith('/'))
			{
				fixUrl = Concat(fixUrl, '/');
			}
			return fixUrl;
		}

	}
}
