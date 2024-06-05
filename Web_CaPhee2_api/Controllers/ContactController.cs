using Microsoft.AspNetCore.Mvc;
using Web_CaPhee2_api.Models.Interface;
using Web_CaPhee2_api.Models;
using Microsoft.AspNetCore.Authorization;


namespace Web_CaPhee2_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ContactController : ControllerBase
	{
		private readonly IContactRepository _contactRepository;

		public ContactController(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		[HttpPost]
		public IActionResult SubmitContactForm(Contact model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_contactRepository.AddContact(model);
					return Ok(new { message = "Contact submission successful." });
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
					return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
				}
			}

			return BadRequest(ModelState);
		}
	}
}
