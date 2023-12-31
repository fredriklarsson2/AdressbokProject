namespace Adressbok.Shared.Interfaces;

public interface IContact
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string StreetAddress { get; set; }
}
