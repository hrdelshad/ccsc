using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ccsc.Web.ViewComponents
{
	#region siteHeader

	public class SiteHeaderComponent : ViewComponent
	{

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("SiteHeader");
		}
	}

	#endregion

	#region siteFooter

	public class SiteFooterComponent : ViewComponent
	{

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("SiteFooter");
		}
	}

	#endregion
}
