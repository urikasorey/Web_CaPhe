using Microsoft.AspNetCore.Mvc;
using Web_CaPhe.Models.Interface;
using Web_CaPhe.Models;

public class ContactController : Controller
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

                
                return RedirectToAction("ContactSuccess");
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
               
            }
        }

        // Nếu dữ liệu không hợp lệ hoặc có lỗi xảy ra, trả về view để hiển thị lỗi
        return View("ContactForm", model);
    }

    public IActionResult ContactSuccess()
    {
        return View();
    }
}
