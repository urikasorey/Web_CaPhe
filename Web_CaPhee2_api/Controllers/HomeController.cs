using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_CaPhee2_api.Models.Interface;

namespace Web_CaPhee2_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public HomeController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet("TrendingProducts")]
		public IActionResult GetTrendingProducts()
		{
			var products = _productRepository.GetTrendingProducts();
			return Ok(products);
		}
	}
}
