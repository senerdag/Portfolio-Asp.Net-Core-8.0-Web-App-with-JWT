using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
