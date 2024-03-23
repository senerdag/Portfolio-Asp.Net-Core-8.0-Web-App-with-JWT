using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

using NToastNotify;
using Portfolio.Dto.LoginDtos;
using Portfolio.Dto.RegisterDtos;
using Portfolio.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Portfolio.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toast;
        public LoginController(IHttpClientFactory httpClientFactory, IToastNotification toast)
        {
            _httpClientFactory = httpClientFactory;
            _toast = toast;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7209/api/Login",content);
            if(response.IsSuccessStatusCode) 
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var tokenModel=JsonSerializer.Deserialize<JwtResponseModel>(jsonData,new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase
                });
                if(tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims=token.Claims.ToList();
                    if(tokenModel.Token!=null)
                    {
                        claims.Add(new Claim("accesToken", tokenModel.Token));
                        var claimsIdentity=new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,

                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            
            return View();
        }
    }
}
