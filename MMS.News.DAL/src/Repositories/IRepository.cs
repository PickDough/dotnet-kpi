using MMS.News.DAL.Entities;

namespace MMS.News.DAL.Repositories;

public interface IRepository<in TKey, TEntity> where TEntity: Entity<TKey>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    TEntity Get(TKey key);
    TEntity Get(Predicate<TEntity> predicate);
    IEnumerable<TEntity> GetAll();
    void Remove(TKey key);
}