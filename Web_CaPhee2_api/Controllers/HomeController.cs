using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_CaPhee2_api.Models.Interface;

namespace Web_CaPhee2_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class HomeController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public HomeController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet("Products")]
		public IActionResult GetTrendingProducts()
		{
			var products = _productRepository.GetTrendingProducts();
			return Ok(products);
		}
	}
}
