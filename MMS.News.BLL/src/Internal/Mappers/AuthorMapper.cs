using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class AuthorMapper
{
    internal static Author? ToDomain(this AuthorEntity? entity)
    {
        if (entity is null)
            return null;
        
        return new Author()
        {
            ID = entity.ID,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            AuthorsNews = entity.AuthorsNews?.Select(_ => _.ToDomain()).ToList(),
        };
    }

    internal static AuthorEntity ToEntity(this Author domain)
    {
        return new AuthorEntity()
        {
            ID = domain.ID,
            FirstName = domain.FirstName,
            LastName = domain.LastName,
        };
    }
}