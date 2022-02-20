using MMS.News.DAL.Public.Entities;

namespace MMS.News.DAL.Public.Repositories;

public interface IRepository<in TKey, TEntity> where TEntity: Entity<TKey>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    TEntity? Get(TKey key);
    TEntity? Get(Func<TEntity, bool> predicate);
    IEnumerable<TEntity> GetAll();
    void Remove(TKey key);
}