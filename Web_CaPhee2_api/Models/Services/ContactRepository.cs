using System.Diagnostics.Contracts;
using Web_CaPhee2_api.Data;
using Web_CaPhee2_api.DTO;
using Web_CaPhee2_api.Models;
using Web_CaPhee2_api.Models.Interface;

public class ContactRepository : IContactRepository
{
    private readonly CoffeeshopApiDbContext _dbContext;

    public ContactRepository(CoffeeshopApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddContact(Contact ContactDTO)
    { 
        try
        {
            var contact = new Contact
            {
                ContactName = ContactDTO.ContactName,
                Email = ContactDTO.Email,
                Message = ContactDTO.Message
            };
            _dbContext.Contact.Add(contact);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("lỗi add contract", ex);
        }
    
    }
}
