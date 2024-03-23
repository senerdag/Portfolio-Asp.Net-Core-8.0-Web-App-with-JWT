using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ResumeDtos;
using System.Text;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminResume")]
    public class AdminResumeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminResumeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7209/api/Resumes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultResumeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateResume")]
        public IActionResult CreateResume()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateResume")]
        public async Task<IActionResult> CreateResume(CreateResumeDto createResumeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(createResumeDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7209/api/Resumes", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminResume", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteResume/{id}")]
        public async Task<IActionResult> DeleteResume(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7209/api/Resumes?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminResume", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateResume/{id}")]
        public async Task<IActionResult> UpdateResume(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7209/api/Resumes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateResumeDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateResume/{id}")]
        public async Task<IActionResult> UpdateResume(UpdateResumeDto updateResumeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateResumeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7209/api/Resumes/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminResume", new { area = "Admin" });
            }
            return View();
        }
    }
}
