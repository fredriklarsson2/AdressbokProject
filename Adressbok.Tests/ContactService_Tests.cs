using Adressbok.Shared.Interfaces;
using Adressbok.Shared.Models;
using Adressbok.Shared.Services;

namespace Adressbok.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToListShould_AddOneContactToContactsList_ThenReturnTrue()
    {
        // Arrange
        IContact contact = new Contact { FirstName = "Test", LastName = "Test", Email = "test@domain.com", PhoneNumber = "0701234567", StreetAddress = "Test" };
        IContactService contactService = new ContactService();

        // Act
        bool result = contactService.AddContactToList(contact);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetContactsFromListShould_GetAllContactsInContactsList_ThenReturnListOfContacts()
    {
        // Arrange
        IContactService contactService = new ContactService();
        IContact contact = new Contact { FirstName = "Test", LastName = "Test", Email = "test@domain.com", PhoneNumber = "0701234567", StreetAddress = "Test" };
        contactService.AddContactToList(contact);

        // Act
        IEnumerable<IContact> result = contactService.GetContactsFromList();

        // Assert
        Assert.NotNull(result);        
        IContact returned_contact = result.FirstOrDefault()!;
        Assert.NotNull(returned_contact);
        Assert.Equal(contact.FirstName, returned_contact.FirstName);
    }
}
