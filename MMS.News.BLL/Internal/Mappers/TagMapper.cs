using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class TagMapper
{
    internal static Tag? ToDomain(this TagEntity? entity)
    {
        if (entity is null)
            return null;

        return new Tag(
            entity.Id,
            entity.Name
        );
    }

    internal static TagEntity ToEntity(this Tag domain)
    {
        return new TagEntity()
        {
            Id = domain.Id,
            Name = domain.Name,
        };
    }
}