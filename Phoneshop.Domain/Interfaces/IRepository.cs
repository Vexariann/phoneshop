namespace Phoneshop.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        void Save();
    }
}
