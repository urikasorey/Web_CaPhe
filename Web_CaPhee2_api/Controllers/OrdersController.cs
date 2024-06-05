using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_CaPhee2_api.Models.Interface;
using Web_CaPhee2_api.Models;
using Microsoft.AspNetCore.Authorization;


namespace Web_CaPhee2_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IShoppingCartRepository _shoppingCartRepository;

		public OrdersController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository)
		{
			_orderRepository = orderRepository;
			_shoppingCartRepository = shoppingCartRepository;
		}

		[HttpPost("Checkout")]
		public IActionResult Checkout(Order order)
		{
			_orderRepository.PlaceOrder(order);
			_shoppingCartRepository.ClearCart();
			return Ok(new { message = "Order placed successfully" });
		}
	}
}
