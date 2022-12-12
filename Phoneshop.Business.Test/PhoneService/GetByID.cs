using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Data;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Test.PhoneService
{
    public class GetByID
    {
        readonly Business.PhoneService _target;
        public GetByID()
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
        [Fact]
        public void Should_Return_Phone()
        {
            //Arrange

            //Act
            Phone returnedPhone = _target.GetByID(3);

            //Assert
            Assert.NotNull(returnedPhone);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(99)]
        public void Should_Return_Null(int index)
        {
            //Arrange

            //Act
            Phone returnedPhone = _target.GetByID(index);

            //Assert
            Assert.Null(returnedPhone);
        }
    }
}