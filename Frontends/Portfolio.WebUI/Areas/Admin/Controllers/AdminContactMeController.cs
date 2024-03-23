using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ContactMeDtos;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContactMe")]
    public class AdminContactMeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactMeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7209/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactMeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("DeleteContactMe/{id}")]
        public async Task<IActionResult> DeleteContactMe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7209/api/Contacts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminContactMe", new { area = "Admin" });
            }
            return View();
        }
    }
}
