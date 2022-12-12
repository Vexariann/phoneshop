using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IPhoneService
    {
        public List<Phone> GetAllPhones();
        public Phone GetByID(int id);
        public Task<List<Phone>> SearchPhone(string input);
        public void AddPhone(Phone phoneToAdd);
        public void DeletePhone(Phone phoneToDelete);
    }
}
