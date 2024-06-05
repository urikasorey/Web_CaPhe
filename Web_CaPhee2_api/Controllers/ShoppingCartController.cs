using Microsoft.AspNetCore.Mvc;
using Web_CaPhee2_api.Models.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Web_CaPhee2_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ShoppingCartController : ControllerBase
	{
		private readonly IShoppingCartRepository shoppingCartRepository;
		private readonly IProductRepository productRepository;

		public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
		{
			this.shoppingCartRepository = shoppingCartRepository;
			this.productRepository = productRepository;
		}

		[HttpGet("items")]
		public IActionResult GetShoppingCartItems()
		{
			var items = shoppingCartRepository.GetAllShoppingCartItems();
			shoppingCartRepository.ShoppingCartItems = items;
			return Ok(new { Items = items, TotalCart = shoppingCartRepository.GetShoppingCartTotal() });
		}

		[HttpPost("add/{pId}")]
		public IActionResult AddToShoppingCart(int pId)
		{
			var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
			if (product != null)
			{
				shoppingCartRepository.AddToCart(product);
				int cartCount = shoppingCartRepository.GetAllShoppingCartItems().Count();
				HttpContext.Session.SetInt32("CartCount", cartCount);
				return Ok(new { CartCount = cartCount });
			}
			return NotFound();
		}

		[HttpPost("remove/{pId}")]
		public IActionResult RemoveFromShoppingCart(int pId)
		{
			var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
			if (product != null)
			{
				shoppingCartRepository.RemoveFromCart(product);
				int cartCount = shoppingCartRepository.GetAllShoppingCartItems().Count();
				HttpContext.Session.SetInt32("CartCount", cartCount);
				return Ok(new { CartCount = cartCount });
			}
			return NotFound();
		}
	}
}
