using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminUILayout")]
    public class AdminUILayoutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
