using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain;
using Phoneshop.Domain.Models;

namespace Phoneshop.Data
{
    public class EntityFrameworkDataContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial " +
            "Catalog=phoneshop2;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}