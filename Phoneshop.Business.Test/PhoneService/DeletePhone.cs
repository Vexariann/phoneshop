using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Test.PhoneService
{
    public class DeletePhone
    {
        public DeletePhone()
        {
            SqlUtils.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial " +
                "Catalog=PhoneshopTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var services = new ServiceCollection();

            services.AddScoped<IPhoneService, Business.PhoneService>();
            services.AddScoped<IBrandService, Business.BrandService>();
            services.AddScoped<IRepository<Phone>, Repository<Phone>>();
            services.AddScoped<IRepository<Brand>, Repository<Brand>>();


            //var provider = services.BuildServiceProvider();

            //IPhoneService phoneService = provider.GetService<IPhoneService>();
            //IBrandService brandService = provider.GetService<IBrandService>();
        }
        readonly Business.PhoneService phoneService;

        [Fact]
        public void Should_Delete_Phone()
        {
            // Arrange
            bool phoneDeleted;

            // Act
            Phone phone = new()
            {
                ID = 999,
                Brand = new Brand() { ID = 999, BrandName = "Apple" },
                Type = "Test Iphone 900",
                Description = "Lorem Ipsum",
                Price = 500,
                Stock = 300
            };
            try
            {
                phoneService.DeletePhone(phone);
                phoneDeleted = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }

            // Assert
            Assert.True(phoneDeleted);
        }
    }
}
