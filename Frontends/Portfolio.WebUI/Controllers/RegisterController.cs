using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using Portfolio.Dto.ContactMeDtos;
using Portfolio.Dto.RegisterDtos;
using System.Text;

namespace Portfolio.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toast;
        public RegisterController(IHttpClientFactory httpClientFactory, IToastNotification toast)
        {
            _httpClientFactory = httpClientFactory;
            _toast = toast;
        }

        [HttpGet]
        public IActionResult CreateAppUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7209/api/Registers", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toast.AddSuccessToastMessage("Your account has been created successfully!");
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
