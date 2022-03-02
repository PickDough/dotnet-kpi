using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Public.Entities;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.DAL.Internal.Repositories;

internal abstract class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : Entity<TKey>
{
    protected DbSet<TEntity> Set;
    protected DbContext Context;

    internal BaseRepository(DbContext context)
    {
        Context = context;
        Set = context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        Set.Add(entity);
        Context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        Set.Update(entity);
        Context.SaveChanges();
    }

    public TEntity? Get(TKey key)
    {
        return GetWhere(e => e.ID!.Equals(key));
    }

    public TEntity? GetWhere(Func<TEntity, bool> predicate)
    {
        return WithInclude()
            .FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return WithInclude().ToList();
    }

    public IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate)
    {
        return WithInclude().Where(predicate).ToList();
    }

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
    {
        return WithInclude()
            .Where(predicate)
            .ToList();
    }

    public void Remove(TKey key)
    {
        var entity = Set.FirstOrDefault(e => e.ID!.Equals(key));
        if (entity is null)
            return;

        Set.Remove(entity);
        Context.SaveChanges();
    }

    protected virtual IEnumerable<TEntity> WithInclude()
    {
        return Set;
    }
}