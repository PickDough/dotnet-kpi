using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class CategoryMapper
{
    internal static Category? ToDomain(this CategoryEntity? entity)
    {
        if (entity is null)
            return null;

        return new Category(
            entity.Id,
            entity.Name
        );
    }

    internal static CategoryEntity ToEntity(this Category domain)
    {
        return new CategoryEntity()
        {
            Id = domain.Id,
            Name = domain.Name,
        };
    }
}