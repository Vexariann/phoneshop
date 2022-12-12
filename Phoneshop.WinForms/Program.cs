using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoneshop.Business;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using Phoneshop.WinForms;

ApplicationConfiguration.Initialize();
var services = new ServiceCollection();
services.AddScoped<IPhoneService, Phoneshop.Business.PhoneService>();
services.AddScoped<IBrandService, Phoneshop.Business.BrandService>();
services.AddScoped<ISqlUtils, SqlUtils>();
services.AddScoped<PhoneOverview>();
services.AddScoped<AddPhone>();
//services.AddScoped<IRepository<Phone>, PhoneRepository>();
//services.AddScoped<IRepository<Brand>, BrandRepository>();
services.AddScoped<IRepository<Phone>, Repository<Phone>>();
services.AddScoped<IRepository<Brand>, Repository<Brand>>();
services.AddLogging(configure => configure.AddDebug()).Configure<LoggerFilterOptions>(options =>
{
    options.MinLevel = LogLevel.Debug;
});
Services.ServiceProvider = services.BuildServiceProvider();
var phoneOverview = Services.ServiceProvider.GetRequiredService<PhoneOverview>();

// To customize application configuration such as set high DPI settings or default font,
// see https://aka.ms/applicationconfiguration.
Application.Run(phoneOverview);