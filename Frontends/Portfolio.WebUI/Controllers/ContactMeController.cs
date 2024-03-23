using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using Portfolio.Dto.ContactMeDtos;
using System.Text;

namespace Portfolio.WebUI.Controllers
{
    public class ContactMeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toast;
        public ContactMeController(IHttpClientFactory httpClientFactory, IToastNotification toast)
        {
            _httpClientFactory = httpClientFactory;
            _toast = toast;
        }



        [HttpPost]
        public async Task<IActionResult> SendContactMessage(CreateContactMeDto createContactMeDto)
        {
            var client = _httpClientFactory.CreateClient();
            createContactMeDto.SendDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(createContactMeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7209/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toast.AddSuccessToastMessage("Your message has been sent successfully!");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
