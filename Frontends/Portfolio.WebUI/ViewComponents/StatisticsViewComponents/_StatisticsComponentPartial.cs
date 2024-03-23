using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
