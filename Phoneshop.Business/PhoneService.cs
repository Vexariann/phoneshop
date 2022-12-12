using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business;

public class PhoneService : IPhoneService
{
    readonly IBrandService _brandService;
    readonly IRepository<Phone> _phoneRepository;
    //readonly ILogger<PhoneService> _logger;

    public PhoneService(IBrandService brandService, IRepository<Phone> phoneRepository/*, ILogger<PhoneService> logger*/)
    {
        _brandService = brandService;
        _phoneRepository = phoneRepository;
        //_logger = logger;
    }

    public List<Phone> GetAllPhones()
    {
        return _phoneRepository.GetAll().Include(p => p.Brand).ToList();
    }


    public Phone GetByID(int id)
    {
        return _phoneRepository.Get(id);
    }

    public async Task<List<Phone>> SearchPhone(string input)
    {
        var searchResults = _phoneRepository.GetAll().Where(p => p.Type.Contains(input) || p.Brand.BrandName.Contains(input) || p.Description.Contains(input)).Include(p => p.Brand);
        return await searchResults.ToListAsync();
    }

    public void AddPhone(Phone phoneObject)
    {
        Phone phoneExists = _phoneRepository.GetAll().SingleOrDefault(p => p.Type == phoneObject.Type && p.Brand.BrandName == phoneObject.Brand.BrandName);
        if (phoneExists == null)
        {
            _brandService.AddBrand(phoneObject);
            _phoneRepository.Add(phoneObject);
            _phoneRepository.Save();
        }
        else
        {
            //_logger.LogInformation($"The phone: {phoneObject.Brand.BrandName} - {phoneObject.Type} already exists in the database");
            throw new Exception($"The phone: {phoneObject.Brand.BrandName} - {phoneObject.Type} already exists in the database");
        }
    }

    public void DeletePhone(Phone phoneToDelete)
    {
        _phoneRepository.Delete(phoneToDelete.ID);
        _phoneRepository.Save();
    }
}