using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ContactMeDtos;
using System.Net.Http;
using System.Text;

namespace Portfolio.WebUI.ViewComponents.ContactComponents
{
    public class _ContactMeComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
