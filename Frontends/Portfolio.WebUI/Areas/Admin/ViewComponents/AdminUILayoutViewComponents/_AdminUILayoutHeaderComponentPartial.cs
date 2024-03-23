using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Areas.Admin.ViewComponents.AdminUILayoutViewComponents
{
    public class _AdminUILayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
