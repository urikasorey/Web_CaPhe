using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Web_CaPhe.Models;
namespace Web_CaPhe.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly HttpClient _httpClient;

		public ShoppingCartController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Index()
		{
			var response = await _httpClient.GetAsync("https://localhost:7166/api/shoppingcart/items");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				var items = JObject.Parse(result)["Items"].ToObject<List<ShoppingCartItem>>();
				ViewBag.TotalCart = JObject.Parse(result)["TotalCart"];
				return View(items);
			}
			return View(new List<ShoppingCartItem>());
		}

		public async Task<IActionResult> AddToShoppingCart(int pId)
		{
			var response = await _httpClient.PostAsync($"https://localhost:7166/api/shoppingcart/add/{pId}", null);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				HttpContext.Session.SetInt32("CartCount", int.Parse(JObject.Parse(result)["CartCount"].ToString()));
			}
			return RedirectToAction("Index", "ShoppingCart");
		}

		public async Task<IActionResult> RemoveFromShoppingCart(int pId)
		{
			var response = await _httpClient.PostAsync($"https://localhost:7166/api/shoppingcart/remove/{pId}", null);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				HttpContext.Session.SetInt32("CartCount", int.Parse(JObject.Parse(result)["CartCount"].ToString()));
			}
			return RedirectToAction("Index");
		}
	}
}
