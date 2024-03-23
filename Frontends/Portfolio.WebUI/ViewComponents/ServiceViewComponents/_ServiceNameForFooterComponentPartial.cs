using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ServiceDtos;

namespace Portfolio.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceNameForFooterComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceNameForFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7209/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceNameForFooterDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
