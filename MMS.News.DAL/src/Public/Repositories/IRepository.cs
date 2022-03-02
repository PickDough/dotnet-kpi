using MMS.News.DAL.Public.Entities;

namespace MMS.News.DAL.Public.Repositories;

public interface IRepository<in TKey, TEntity> where TEntity: Entity<TKey>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    TEntity? Get(TKey key);
    TEntity? GetWhere(Func<TEntity, bool> predicate);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate);
    void Remove(TKey key);
}