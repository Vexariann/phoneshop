using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Test.PhoneService
{
    public class AddPhone
    {
        public AddPhone()
        {
            SqlUtils.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial " +
                "Catalog=PhoneshopTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var services = new ServiceCollection();

            services.AddScoped<IPhoneService, Business.PhoneService>();
            services.AddScoped<IBrandService, Business.BrandService>();
            services.AddScoped<ISqlUtils, SqlUtils>();
            services.AddScoped<IRepository<Phone>, Repository<Phone>>();
            services.AddScoped<IRepository<Brand>, Repository<Brand>>();
        }
        readonly IPhoneService _target;

        [Fact]
        public void Should_Add_Phone()
        {
            // Arrange
            bool phoneAdded;

            // Act
            Brand brand = new()
            {
                BrandName = "Apple"
            };
            Phone phone = new()
            {
                //Brand = "Apple",
                Type = "Test Iphone 900",
                Description = "Lorem Ipsum",
                Price = 500,
                Stock = 300,
                Brand = brand,
                BrandID = 0
            };
            try
            {
                _target.AddPhone(phone);
                phoneAdded = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }

            // Assert
            Assert.True(phoneAdded);
        }
    }
}
