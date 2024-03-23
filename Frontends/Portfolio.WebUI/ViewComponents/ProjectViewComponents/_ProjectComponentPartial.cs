using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.ProjectDtos;

namespace Portfolio.WebUI.ViewComponents.ProjectViewComponents
{
    public class _ProjectComponentPartial:ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _ProjectComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7209/api/Projects");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProjectDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
