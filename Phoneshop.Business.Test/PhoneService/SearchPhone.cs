using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Test.PhoneService
{
    public class SearchPhone
    {
        readonly Business.PhoneService _target;
        public SearchPhone()
        {
            SqlUtils.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial " +
                "Catalog=PhoneshopTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var services = new ServiceCollection();

            services.AddScoped<Business.PhoneService>();
            services.AddScoped<ISqlUtils, SqlUtils>();
            services.AddScoped<IRepository<Phone>, Repository<Phone>>();

            var provider = services.BuildServiceProvider();

            _target = provider.GetRequiredService<Business.PhoneService>();
        }

        [Theory]
        [InlineData("Huawei")]
        [InlineData("Camera")]
        [InlineData("Def")]
        [InlineData("")]
        public async Task Should_Return_PhoneList(string searchQuery)
        {
            //Arrange

            //Act
            List<Phone> returnedPhones = searchQuery.Length > 3 ? await _target.SearchPhone(searchQuery) : _target.GetAllPhones();

            //Assert
            Assert.NotEmpty(returnedPhones);
        }

        [Fact]
        public async Task Should_Return_Empty()
        {
            //Arrange

            //Act
            List<Phone> returnedPhones = await _target.SearchPhone("A very long search query");

            //Assert
            Assert.Empty(returnedPhones);
        }
    }
}
