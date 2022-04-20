using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class NewsMapper
{
    internal static Public.Domain.News? ToDomain(this NewsEntity? entity)
    {
        if (entity is null)
            return null;
        
        return new Public.Domain.News()
        {
            ID = entity.ID,
            Headline = entity.Headline,
            Content = entity.Content,
            DatePublished = entity.DatePublished,
            AuthorId = entity.AuthorID,
            Author = entity.Author?.ToDomain(),
            CategoryId = entity.CategoryID,
            Category = entity.Category?.ToDomain(),
            Tags = entity.Tags?.Select(_ => _.ToDomain()).ToList(),
        };
    }

    internal static NewsEntity ToEntity(this Public.Domain.News domain)
    {
        return new NewsEntity()
        {
            ID = domain.ID,
            Headline = domain.Headline,
            Content = domain.Content,
            DatePublished = domain.DatePublished,
            AuthorID = domain.AuthorId,
            CategoryID = domain.CategoryId,
            Tags = domain.Tags!.Select(_ => _.ToEntity()).ToList(),
        };
    }
}