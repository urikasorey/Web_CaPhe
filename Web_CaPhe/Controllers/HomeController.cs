using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web_CaPhe.Models;
using Web_CaPhe.Models.Interface;

public class HomeController : Controller
{
	private readonly IProductRepository _productRepository;
	private readonly HttpClient _httpClient;

	public HomeController(IProductRepository productRepository, IHttpClientFactory httpClientFactory)
	{
		_productRepository = productRepository;
		_httpClient = httpClientFactory.CreateClient();
	}

	public async Task<IActionResult> Index()
	{
		var response = await _httpClient.GetAsync("https://localhost:7166/api/home/TrendingProducts");

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();
			var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return View(products);
		}

		// Handle error or return an empty view
		return View(new List<Product>());
	}

	public IActionResult Contact()
	{
		return View();
	}

	public IActionResult Login()
	{
		return View();
	}
}
