using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class CategoryMapper
{
    internal static Category? ToDomain(this CategoryEntity? entity)
    {
        if (entity is null)
            return null;
        
        return new Category()
        {
            ID = entity.ID,
            Name = entity.Name,
        };
    }
    
    internal static CategoryEntity ToEntity(this Category domain)
    {
        return new CategoryEntity()
        {
            ID = domain.ID,
            Name = domain.Name,
        };
    }
}