using JWTCQRSProject.UI.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace JWTCQRSProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public AccountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            var model = new UserLoginModel();
            return View(model);
        }
        [HttpPost]
		public async Task<IActionResult> Login(UserLoginModel model)
		{
            if (ModelState.IsValid) 
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8,"application/json");
                var response = await client.PostAsync("http://localhost:5017/api/Auth/Login",content);
                if (response.IsSuccessStatusCode) 
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtTokeResponseModel>(json,new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                    if (tokenModel != null) 
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(tokenModel.Token);
                        var claims = token.Claims.ToList();
                        if (tokenModel.Token != null)
                        {
							claims.Add(new Claim("accesToken", tokenModel.Token));
						}
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties { ExpiresUtc = tokenModel.ExpireDate,IsPersistent = true};
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProps);
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya şifre hatalı");
                }
            }
            return View(model);
		}
	}
}
