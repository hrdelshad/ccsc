using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ccsc.Core.Extensions
{
	public static class CommonExtensions
	{
		//public static string GetEntityName(this System.ComponentModel.DataAnnotations.DisplayAttribute displayAttribute)
		//{
		//	var displayName = displayAttribute.GetName();
		//	return displayName;
		//}

		public static string GetEnumName(this System.Enum myEnum)
		{
			var enumDisplayName = myEnum.GetType().GetMember(myEnum.ToString()).FirstOrDefault();
			return enumDisplayName != null ? enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName() : "";
		}
		
	}
}
