using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

//LoggerFactory factory = new();
//factory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));

//using IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureLogging(builder =>
//        builder.ClearProviders().AddEventLog())
//            .Build();

//using var loggerFactory = LoggerFactory.Create(builder =>
//{
//    builder
//        .AddFilter("Microsoft", LogLevel.Warning)
//        .AddFilter("System", LogLevel.Warning)
//        .AddFilter("Phoneshop.ConsoleApp.Program", LogLevel.Debug)
//        .AddConsole();
//});

//ILogger logger = loggerFactory.CreateLogger<Program>();
//logger.LogInformation("Example log message");

var services = new ServiceCollection();
services.AddScoped<IPhoneService, PhoneService>();
services.AddScoped<IBrandService, BrandService>();
services.AddScoped<IRepository<Phone>, Repository<Phone>>();
services.AddScoped<IRepository<Brand>, Repository<Brand>>();
services.AddScoped<ISqlUtils, SqlUtils>();
//services.AddLogging(config => config.AddEventLog());
var provider = services.BuildServiceProvider();

Console.OutputEncoding = System.Text.Encoding.UTF8;

//ILogger logger = provider.GetService<ILogger>();
//var logger = host.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation($"{DateTime.Now} Starting application");
string input = "";
bool searchMode = false;
IPhoneService service = provider.GetService<IPhoneService>();
MainMenu(service.GetAllPhones());

void MainMenu(List<Phone> phones)
{
    Console.WriteLine("============================================================================" +
        "===================");
    WriteColoredLine(ConsoleColor.Cyan, "Welkom bij de Phoneshop console applicatie");
    Console.WriteLine($"Typ een ID nummer van een van de telefoons in om meer informatie te krijgen " +
        $"over die telefoon.");
    Console.WriteLine($"Typ 'Zoek' om een telefoon te zoeken, typ 'Quit' om de applicatie af te " +
        $"sluiten.");
    Console.WriteLine("============================================================================" +
        "===================\n");

    int index = 1;
    foreach (Phone phone in phones)
    {
        Console.WriteLine($"{index} {phone.Brand.BrandName} {phone.Type}\n");
        index++;
    }
    //logger.LogInformation($"{DateTime.Now} Fetched all phones");

    MainInput(phones);
}

void DrawPhoneInformation(Phone selectedPhone, int phoneID)
{
    if (selectedPhone != null)
    {
        Console.WriteLine($"==========================================================");
        WriteColoredLine(ConsoleColor.Cyan, $"Informatie over {selectedPhone.Brand.BrandName} {selectedPhone.Type}");
        Console.WriteLine($"==========================================================");

        WriteColoredLine(ConsoleColor.Yellow, "\nTelefoon Merk:");
        Console.WriteLine($"{selectedPhone.Brand.BrandName}");

        WriteColoredLine(ConsoleColor.Yellow, "\nTelefoon Type:");
        Console.WriteLine($"{selectedPhone.Type}");

        WriteColoredLine(ConsoleColor.Yellow, "\nPrijs:");
        Console.WriteLine($"€{selectedPhone.Price} (Zonder BTW: €{selectedPhone.PriceNoVAT})");

        WriteColoredLine(ConsoleColor.Yellow, "\nOmschrijving:");
        Console.WriteLine($"{selectedPhone.Description}");

        //logger.LogInformation($"{DateTime.Now} succesfully loaded phone {selectedPhone.Brand.BrandName} {selectedPhone.Type}");
    }

    ReturnKey();
}

async Task SearchPhoneInput()
{
    Console.Clear();
    Console.WriteLine("Zoek een telefoon\n");
    Console.ForegroundColor = ConsoleColor.Yellow;
    input = Console.ReadLine();
    Console.ResetColor();
    Console.Clear();
    FetchSearchedPhoneInformation(await service.SearchPhone(input));
}

void FetchSearchedPhoneInformation(List<Phone> searchedResults)
{
    if (searchedResults.Count > 0)
    {
        Console.WriteLine($"===================================================");
        WriteColoredLine(ConsoleColor.Cyan, $"Gevonden telefoons met uw zoekopdracht: {input}");
        Console.WriteLine($"Typ 'Stop' in om uw zoekopdracht te stoppen en weer");
        Console.WriteLine($"terug te gaan naar het hoofdmenu");
        Console.WriteLine($"===================================================\n");

        int index = 1;
        foreach (Phone phone in searchedResults)
        {
            Console.WriteLine($"{index} {phone.Brand.BrandName} {phone.Type}\n");
            index++;
        }
        //logger.LogInformation($"{DateTime.Now} Succesfully found list of phones with search query: {input}");

        searchMode = true;
        MainInput(searchedResults);
    }
    else
    {
        input = "";
        WriteErrorMessage("Uw zoekopdracht heeft geen resultaten opgeleverd");
    }
}

async void MainInput(List<Phone> phoneList)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    string mainInput = Console.ReadLine();
    Console.ResetColor();

    if (!string.IsNullOrEmpty(mainInput))
    {
        mainInput = mainInput.ToLower();
        Console.Clear();

        if (searchMode == false && mainInput == "quit")
        {
            Quit();
        }
        else if (searchMode == false && mainInput == "zoek")
        {
            await SearchPhoneInput();
        }
        else if (searchMode == true && mainInput == "stop")
        {
            input = "";
            searchMode = false;
            MainMenu(service.GetAllPhones());
        }

        if (int.TryParse(mainInput, out int mainInputInt))
        {
            int index = mainInputInt - 1;
            try
            {
                int phoneID = phoneList[index].ID;
                DrawPhoneInformation(service.GetByID(phoneID), mainInputInt);
            }
            catch
            {
                WriteErrorMessage($"Missende data: De data voor de telefoon met " +
                    $"ID {mainInput} bestaat niet. Gebruik een ander nummer.");
            }
        }
        else
            WriteErrorMessage("Ongeldig commando!");
    }
    else
        WriteErrorMessage($"Leeg invoerveld: Je hebt niks ingevoerd in het invoerveld.");
}

void Quit()
{
    Console.Clear();
    //logger.LogInformation($"{DateTime.Now} Closing application");
    WriteColoredLine(ConsoleColor.Cyan, "Sluit de applicatie af. Druk op een willekeurige toets om af te sluiten");
    Environment.Exit(0);
}

void WriteErrorMessage(string message)
{
    Console.Clear();
    WriteColoredLine(ConsoleColor.Red, message);
    ReturnKey();
}

void WriteColoredLine(ConsoleColor consoleColor, string message)
{
    Console.ForegroundColor = consoleColor;
    Console.WriteLine(message);
    Console.ResetColor();
}

async void ReturnKey()
{
    Console.WriteLine("\nDruk op een willekeurige toets om weer terug te gaan");
    Console.ReadKey(true);
    Console.Clear();
    if (input == "")
    {
        MainMenu(service.GetAllPhones());
    }
    else
    {
        FetchSearchedPhoneInformation(await service.SearchPhone(input));
    }
}