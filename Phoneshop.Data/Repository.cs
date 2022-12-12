using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly EntityFrameworkDataContext _dataContext = new();
        public void Add(TEntity entity)
        {
            _dataContext.Add(entity);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                _dataContext.Remove(item);
            }
        }

        public TEntity Get(int id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> GetAll() => _dataContext.Set<TEntity>();

        public void Update(TEntity entity) => throw new NotImplementedException();

    }
}
