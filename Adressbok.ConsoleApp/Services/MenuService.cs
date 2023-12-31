using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using Adressbok.Shared.Interfaces;
using Adressbok.Shared.Models;
using Adressbok.Shared.Services;
using Microsoft.VisualBasic;

namespace Adressbok.ConsoleApp.Services;

internal class MenuService
{
    private static readonly IContactService _contactService = new ContactService();

    // Add contact to list.
    public static void AddContactMenu()
    {
        IContact contact = new Contact();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\tADRESSBOK ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("// Skapa kontakt");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\t¯¯¯¯¯¯¯¯¯");

        Console.Write("\tFörnamn: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("\tEfternamn: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("\tEmail: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("\tTelefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("\tGatuadress: ");
        contact.StreetAddress = Console.ReadLine()!;

        _contactService.AddContactToList(contact);
    }

    // Remove contact from list.
    public static void RemoveContact()
    {
        if (_contactService.GetContactsFromList().Count() > 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\tADRESSBOK ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("// Ta bort kontakt");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t¯¯¯¯¯¯¯¯¯");
            Console.WriteLine("\tAnge e-postadress för kontakten du vill ta bort:");
            Console.Write("\n\t");
            string email = Console.ReadLine()!;

            var contact = _contactService.GetContactFromList(email);

            if (contact != null)
            {
                _contactService.RemoveContactFromList(contact);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tKontakten är borttagen!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tKontakten hittades inte.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tInga kontakter hittades.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write("\n\t");
    }

    // Show all contacts on list.
    public static void ShowAllContactsMenu()
    {
        if (_contactService.GetContactsFromList().Count() > 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\tADRESSBOK ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("// Visa alla kontakter");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t¯¯¯¯¯¯¯¯¯");

            var _contacts = _contactService.GetContactsFromList();

            foreach (var contact in _contacts)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\t{contact.FirstName.ToUpper()} {contact.LastName.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\t[{contact.Email}]");
            }
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tInga kontakter hittades.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        Console.Write("\n\t");
    }

    // Show detailed information about contact from list.
    public static void ShowContactDetails()
    {
        if (_contactService.GetContactsFromList().Count() > 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\tADRESSBOK ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("// Visa detaljerad information");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t¯¯¯¯¯¯¯¯¯");

            Console.WriteLine("\tAnge e-postadress för kontakten du vill visa detaljer för:");
            Console.Write("\n\t");

            string email = Console.ReadLine()!;

            var contact = _contactService.GetContactFromList(email);

            if (contact != null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\tADRESSBOK ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"// {email}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t¯¯¯¯¯¯¯¯¯");

                Console.Write("\tNamn: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{contact.FirstName.ToUpper()} {contact.LastName.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\tE-post: {contact.Email}");
                Console.WriteLine($"\tTelefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"\tAdress: {contact.StreetAddress}");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tKontakten hittades inte.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tInga kontakter hittades.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write("\n\t");
    }
}
