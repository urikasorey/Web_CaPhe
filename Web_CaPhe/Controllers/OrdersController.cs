using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web_CaPhe.Models.Interface;
using Web_CaPhe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Web_CaPhe.Controllers
{
	[Authorize]
	public class OrdersController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IShoppingCartRepository _shoppingCartRepository;
		private readonly HttpClient _httpClient;

		public OrdersController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, IHttpClientFactory httpClientFactory)
		{
			_orderRepository = orderRepository;
			_shoppingCartRepository = shoppingCartRepository;
			_httpClient = httpClientFactory.CreateClient();
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(Order order)
		{
			if (ModelState.IsValid)
			{
				var json = JsonSerializer.Serialize(order);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync("https://localhost:7166/api/orders/Checkout", content);

				if (response.IsSuccessStatusCode)
				{
					_shoppingCartRepository.ClearCart();
					HttpContext.Session.SetInt32("CartCount", 0);
					return RedirectToAction("CheckoutComplete");
				}
				else
				{
					ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
				}
			}

			return View(order);
		}

		public IActionResult CheckoutComplete()
		{
			return View();
		}
	}
}
