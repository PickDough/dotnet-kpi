using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class AuthorMapper
{
    internal static Author? ToDomain(this AuthorEntity? entity, bool deepMapping = true)
    {
        if (entity is null)
            return null;

        return new Author(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            deepMapping ? entity.AuthorsNews?.Select(_ => _.ToDomain()).ToList()! : new List<Public.Domain.News>()
        );
    }

    internal static AuthorEntity ToEntity(this Author domain)
    {
        return new AuthorEntity()
        {
            Id = domain.Id,
            FirstName = domain.FirstName,
            LastName = domain.LastName,
        };
    }
}