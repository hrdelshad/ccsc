using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ccsc.Web.ViewComponents
{
	public class UserTypeComponent : ViewComponent
	{

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult((IViewComponentResult) View("UserType"));
		}
	}
}
