using JWTCQRSProject.UI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace JWTCQRSProject.UI.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("http://localhost:5017/api/products");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ProductListModel>>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    return View(result);
                }
            }
            return View();
        }
  
		public async Task<IActionResult> Remove(int id)
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
				var response = await client.DeleteAsync($"http://localhost:5017/api/products/{id}");
			}
			return RedirectToAction("List");
		}
        public async Task<IActionResult> Create()
        {
            var model = new ProductCreateModel();
			var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
				var response = await client.GetAsync($"http://localhost:5017/api/categories/");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData,new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                    model.Categories = new SelectList(data,"Id", "Definations");

					return View(model);
                }
            }
			return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
			var data = TempData["Categories"]?.ToString();
            if (data != null)
            {
                var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
                model.Categories = new SelectList(categories, "Value", "Text");
            }
            if (ModelState.IsValid) 
            {
				var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
				if (token != null)
				{
					var client = _httpClientFactory.CreateClient();
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					var jsonData = JsonSerializer.Serialize(model);
					var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
					var response = await client.PostAsync($"http://localhost:5017/api/products/",content);
				}
			}
            return View(model);
        }
		public async Task<IActionResult> Update(int id)
		{
			var model = new UpdateProductModel();
			var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
				var responseCategory = await client.GetAsync($"http://localhost:5017/api/categories/");
				var responseProduct = await client.GetAsync($"http://localhost:5017/api/products/{id}");
				if (responseProduct.IsSuccessStatusCode && responseCategory.IsSuccessStatusCode)
				{
                    var jsonDataCategory = await responseCategory.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonDataCategory, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    var jsonDataProduct = await responseProduct.Content.ReadAsStringAsync();
					var result = JsonSerializer.Deserialize<UpdateProductModel>(jsonDataProduct, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
					if (result != null)
					{
						result.Categories = new SelectList(data, "Id", "Definations");
                    }
					return View(result);
				}
			}
			return RedirectToAction("List");
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductModel model)
		{
			var data = TempData["Categories"]?.ToString();
			if (data != null)
			{
				var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
				model.Categories = new SelectList(categories, "Value", "Text",model.CategoryId);
			}
			if (ModelState.IsValid)
			{
				var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
				if (token != null)
				{
					var client = _httpClientFactory.CreateClient();
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					var jsonData = JsonSerializer.Serialize(model);
					var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
					var response = await client.PutAsync($"http://localhost:5017/api/products/", content);
				}
			}
			return View(model);
		}
	}
}
