using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ContactInfoDtos;
using System.Text;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContactInfo")]
    public class AdminContactInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7209/api/ContactInfos");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactInfoDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateContactInfo")]
        public IActionResult CreateContactInfo()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateContactInfo")]
        public async Task<IActionResult> CreateContactInfo(CreateContactInfoDto createContactInfoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(createContactInfoDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7209/api/ContactInfos", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminContactInfo", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteContactInfo/{id}")]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7209/api/ContactInfos?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminContactInfo", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateContactInfo/{id}")]
        public async Task<IActionResult> UpdateContactInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7209/api/ContactInfos/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactInfoDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateContactInfo/{id}")]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoDto updateContactInfoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactInfoDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7209/api/ContactInfos/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminContactInfo", new { area = "Admin" });
            }
            return View();
        }
    }
}
