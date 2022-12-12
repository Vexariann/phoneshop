using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business
{
    public class BrandService : IBrandService
    {
        readonly IRepository<Brand> _brandRepository;
        public BrandService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public void AddBrand(Phone phoneToAdd)
        {
            Brand brandExists = _brandRepository.GetAll().SingleOrDefault(p => p.BrandName == phoneToAdd.Brand.BrandName);
            if (brandExists != null)
            {
                phoneToAdd.Brand = null;
                phoneToAdd.BrandID = brandExists.ID;
            }
        }

        public int GetBrandId(string brandName)
        {
            var brandInt = _brandRepository.GetAll().Where(b => b.BrandName == brandName).FirstOrDefault().ID;
            return brandInt;
        }

        public void DeleteBrand(Brand brandToDelete)
        {
            _brandRepository.Delete(brandToDelete.ID);
        }
    }
}
