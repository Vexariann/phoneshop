using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Business.Scrapers;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

var services = new ServiceCollection();
services.AddScoped<IScraper, BelsimpelScraper>();
services.AddScoped<IScraper, VodafoneScraper>();
services.AddScoped<IPhoneService, PhoneService>();
services.AddScoped<IBrandService, BrandService>();
services.AddScoped<IRepository<Phone>, Repository<Phone>>();
services.AddScoped<IRepository<Brand>, Repository<Brand>>();
var provider = services.BuildServiceProvider();

IScraper scraper = provider.GetService<IScraper>();
IPhoneService service = provider.GetService<IPhoneService>();

MainMenu();

void MainMenu()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("Welcome to the Phoneshop scraper.");
    Console.WriteLine("Please select an option below");
    Console.WriteLine("=================================");
    Console.WriteLine();
    Console.WriteLine("1. Scrape through all scrapers");
    Console.WriteLine("2. Scrape through a specific website");
    ConsoleKeyInfo pressedkey = Console.ReadKey();
    bool parsed = int.TryParse(pressedkey.KeyChar.ToString(), out int pressedKeyNumber);
    if (parsed == true)
    {
        if (pressedKeyNumber == 1)
        {
            //AddScrapedPhones(scraper.Execute("https://www.belsimpel.nl/telefoon"));
            throw new HttpRequestException("Belsimpel site not working");
        }
        else if (pressedKeyNumber == 2)
        {
            ScraperMenu();
        }
        else
        {
            InvalidCommandError();
            Console.ReadKey();
            MainMenu();
        }
    }
    else
    {
        InvalidCommandError();
        Console.ReadKey();
        MainMenu();
    }
}

void ScraperMenu()
{
    Console.Clear();
    Console.WriteLine("====================================");
    Console.WriteLine("Select one of the available scrapers");
    Console.WriteLine("to get started. Or press 3 to return");
    Console.WriteLine("to the main menu.");
    Console.WriteLine("====================================");
    Console.WriteLine();
    Console.WriteLine("1. Scrape through BelSimpel");
    Console.WriteLine("2. Scrape through Vodafone");
    Console.WriteLine("3. Return to the main menu");
    ConsoleKeyInfo pressedkey = Console.ReadKey();
    bool parsed = int.TryParse(pressedkey.KeyChar.ToString(), out int pressedKeyNumber);
    if (parsed == true)
    {
        if (pressedKeyNumber == 1)
        {
            throw new HttpRequestException("Belsimpel site not working");
        }
        else if (pressedKeyNumber == 2)
        {
            throw new NotImplementedException("Vodafone scraper needs to be implemented.");
        }
        else if (pressedKeyNumber == 3)
        {
            MainMenu();
        }
        else
        {
            InvalidCommandError();
            Console.ReadKey();
            ScraperMenu();
        }
    }
    else
    {
        InvalidCommandError();
        Console.ReadKey();
        ScraperMenu();
    }
}

//AddScrapedPhones(scraper.Execute("https://www.belsimpel.nl/telefoon"));
void AddScrapedPhones(List<Phone> phoneList)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Web page loading, please wait.");
    Console.Write("");
    Console.ResetColor();

    foreach (Phone phone in phoneList)
    {
        try
        {
            service.AddPhone(phone);
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
    Console.ReadKey();
    Environment.Exit(0);
}

void InvalidCommandError()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invalid command!");
    Console.ResetColor();
    Console.WriteLine("Press any key to return");
}
