using System.Diagnostics;
using Adressbok.Shared.Interfaces;
using Newtonsoft.Json;

namespace Adressbok.Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService = new FileService();
    private List<IContact> _contacts = new List<IContact>();
    private readonly string _filePath = @"C:\source\test\contacts.json";

    // Add Contact From List
    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    // Remove Contact From List
    public bool RemoveContactFromList(IContact contact)
    {
        try
        {
            if (_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Remove(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    // Get Contact From List
    public IContact GetContactFromList(string email)
    {
        try
        {
            GetContactsFromList();

            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<IContact> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
