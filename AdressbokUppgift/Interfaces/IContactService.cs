namespace Adressbok.Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(IContact contact);
    bool RemoveContactFromList(IContact contact);
    IEnumerable<IContact> GetContactsFromList();
    IContact GetContactFromList(string email);
}
