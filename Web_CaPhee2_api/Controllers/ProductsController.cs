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
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet("Shop")]
		public IActionResult GetAllProducts()
		{
			var products = _productRepository.GetAllProducts();
			return Ok(products);
		}

		[HttpGet("Detail/{id}")]
		public IActionResult GetProductDetail(int id)
		{
			var product = _productRepository.GetProductDetail(id);
			if (product != null)
			{
				return Ok(product);
			}
			return NotFound();
		}
	}
}
