using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandService
    {
        public void AddBrand(Phone phoneToAdd);
        public int GetBrandId(string brandName);
        public void DeleteBrand(Brand brandToDelete);
    }
}
