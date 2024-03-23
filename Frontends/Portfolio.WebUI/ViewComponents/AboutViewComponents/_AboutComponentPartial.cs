using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.AboutDtos;

namespace Portfolio.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _AboutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7209/api/Abouts");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
