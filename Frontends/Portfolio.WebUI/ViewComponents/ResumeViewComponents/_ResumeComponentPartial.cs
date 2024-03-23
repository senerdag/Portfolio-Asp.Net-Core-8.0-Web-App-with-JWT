using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ResumeDtos;

namespace Portfolio.WebUI.ViewComponents.ResumeViewComponents
{
    public class _ResumeComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ResumeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
