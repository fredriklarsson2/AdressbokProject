using Adressbok.ConsoleApp.Services;
using Adressbok.Shared.Models;

namespace Adressbok.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tADRESSBOK");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t¯¯¯¯¯¯¯¯¯");
            Console.WriteLine("\t1. Skapa kontakt.");
            Console.WriteLine("\t2. Visa alla kontakter.");
            Console.WriteLine("\t3. Visa detaljerad information.");
            Console.WriteLine("\t4. Ta bort kontakt.");
            Console.WriteLine("\t5. Avsluta programmet.\n");
            Console.Write("\t"); // input

            if(Int32.TryParse(Console.ReadLine(), out int input))
            {
                switch (input)
                {
                    case 1:
                        MenuService.AddContactMenu();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\tKontakten har skapats!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 2:
                        if(File.Exists(@"C:\source\test\contacts.json"))
                        {
                            MenuService.ShowAllContactsMenu();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\tFilen existerar inte.");
                        }
                        break;

                    case 3:
                        if (File.Exists(@"C:\source\test\contacts.json"))
                        {
                            MenuService.ShowContactDetails();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\tFilen existerar inte.");
                        }
                        break;

                    case 4:
                        if (File.Exists(@"C:\source\test\contacts.json"))
                        {
                            MenuService.RemoveContact();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\tFilen existerar inte.");
                        }
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\tVälj mellan 1 och 5.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tVälj en siffra mellan 1 och 5.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            Console.ReadKey();
            Console.Clear();
        }
    }
}