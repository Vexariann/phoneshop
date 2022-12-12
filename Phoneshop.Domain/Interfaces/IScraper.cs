using Phoneshop.Domain.Models;

namespace Phoneshop.Domain.Interfaces
{
    public interface IScraper
    {
        public bool CanExecute();
        public List<Phone> Execute(string url);
    }
}
