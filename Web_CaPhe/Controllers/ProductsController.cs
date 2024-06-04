using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web_CaPhe.Models;
using Web_CaPhe.Models.Interface;

namespace Web_CaPhe.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly HttpClient _httpClient;

		public ProductsController(IProductRepository productRepository, IHttpClientFactory httpClientFactory)
		{
			_productRepository = productRepository;
			_httpClient = httpClientFactory.CreateClient();
		}

		public async Task<IActionResult> Shop()
		{
			var response = await _httpClient.GetAsync("https://localhost:7166/api/products/shop");
			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				return View(products);
			}

			// Handle error or return an empty view
			return View(new List<Product>());
		}

		public async Task<IActionResult> Detail(int id)
		{
			var response = await _httpClient.GetAsync($"https://localhost:7166/api/products/detail/{id}");
			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var product = JsonSerializer.Deserialize<Product>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				if (product != null)
				{
					return View(product);
				}
			}

			return NotFound();
		}
	}
}
