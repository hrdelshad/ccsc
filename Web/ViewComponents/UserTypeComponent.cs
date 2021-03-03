using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
