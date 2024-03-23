using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _HeadUILayoutComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
