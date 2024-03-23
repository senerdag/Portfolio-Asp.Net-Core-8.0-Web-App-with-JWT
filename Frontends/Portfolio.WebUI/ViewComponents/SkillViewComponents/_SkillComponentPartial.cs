using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Dto.SkillDtos;

namespace Portfolio.WebUI.ViewComponents.SkillViewComponents
{
    public class _SkillComponentPartial:ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _SkillComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7209/api/Skills");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSkillDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
