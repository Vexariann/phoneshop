using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

var services = new ServiceCollection();
services.AddScoped<IPhoneService, PhoneService>();
services.AddScoped<IBrandService, BrandService>();
services.AddScoped<ISqlUtils, SqlUtils>();
services.AddScoped<IRepository<Phone>, Repository<Phone>>();
services.AddScoped<IRepository<Brand>, Repository<Brand>>();
var provider = services.BuildServiceProvider();

Console.WriteLine("=============================================");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Welcome the the Phoneshop XML importing tool.");
Console.ResetColor();
Console.WriteLine("=============================================");
Console.WriteLine("");
Console.WriteLine($"Please copy the filepath of a valid XML file.\n");

Console.ForegroundColor = ConsoleColor.Yellow;
string input = Console.ReadLine();
Console.ResetColor();

IPhoneService phoneService = provider.GetService<IPhoneService>();
try
{
    Message(XMLReaderService.OpenXMLFile(input));
}
catch
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Your specified path name of: {input} either doesn't exist or is not a valid XML file.");
    Console.ResetColor();
}

void Message(List<Phone> phoneList)
{

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Valid XML file found and processed! Proceeding to adding the new phones to the database.\n");
    Console.ResetColor();
    foreach (Phone phone in phoneList)
    {
        try
        {
            phoneService.AddPhone(phone);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"successfully added {phone.Brand} - {phone.Type} to the database");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{ex.Message}");
            Console.ResetColor();
        }
    }
}