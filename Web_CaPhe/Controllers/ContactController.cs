using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web_CaPhe.Models;
using Web_CaPhe.Models.Interface;

public class ContactController : Controller
{
	private readonly IContactRepository _contactRepository;
	private readonly HttpClient _httpClient;

	public ContactController(IContactRepository contactRepository, IHttpClientFactory httpClientFactory)
	{
		_contactRepository = contactRepository;
		_httpClient = httpClientFactory.CreateClient();
	}

	[HttpPost]
	public async Task<IActionResult> SubmitContactForm(Contact model)
	{
		if (ModelState.IsValid)
		{
			try
			{
				// Serialize the model to JSON
				var json = JsonSerializer.Serialize(model);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				// Send a POST request to the API Controller
				var response = await _httpClient.PostAsync("https://localhost:7166/api/contact", content);

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("ContactSuccess");
				}
				else
				{
					ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
			}
		}

		// If the data is invalid or an error occurs, return the view to display the error
		return View("ContactForm", model);
	}

	public IActionResult ContactSuccess()
	{
		return View();
	}
}
