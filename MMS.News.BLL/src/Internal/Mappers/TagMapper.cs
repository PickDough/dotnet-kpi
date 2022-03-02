using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class TagMapper
{
    internal static Tag? ToDomain(this TagEntity? entity)
    {
        if (entity is null)
            return null;
        
        return new Tag()
        {
            ID = entity.ID,
            Name = entity.Name,
        };
    }
    
    internal static TagEntity ToEntity(this Tag domain)
    {
        return new TagEntity()
        {
            ID = domain.ID,
            Name = domain.Name,
        };
    }
}