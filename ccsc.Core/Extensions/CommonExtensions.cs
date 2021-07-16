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

		public static string GetEnumName(this System.Enum MyEnum)
		{
			var enumDisplayName = MyEnum.GetType().GetMember(MyEnum.ToString()).FirstOrDefault();
			if(enumDisplayName != null)
			{
				return enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName();
			}
			return "";
		}
		
	}
}
