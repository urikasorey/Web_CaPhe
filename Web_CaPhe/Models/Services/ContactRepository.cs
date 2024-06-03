using Web_CaPhe.Data;
using Web_CaPhe.Models;
using Web_CaPhe.Models.Interface;

public class ContactRepository : IContactRepository
{
    private readonly CoffeeshopDbContext _dbContext;

    public ContactRepository(CoffeeshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddContact(Contact contact)
    {
        _dbContext.Contact.Add(contact);
        _dbContext.SaveChanges(); 
    }
}
