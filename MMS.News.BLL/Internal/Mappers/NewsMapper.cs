using MMS.News.BLL.Public.Domain;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.BLL.Internal.Mappers;

internal static class NewsMapper
{
    internal static Public.Domain.News? ToDomain(this NewsEntity? entity, bool deepMapping = true)
    {
        if (entity is null)
            return null;

        return new Public.Domain.News(
            entity.Id,
            entity.Headline,
            entity.Content,
            entity.DatePublished,
            entity.AuthorId,
            deepMapping ? entity.Author?.ToDomain(false) : null,
            entity.CategoryId,
            entity.Category?.ToDomain(),
            deepMapping ? entity.Tags?.Select(_ => _.ToDomain()).ToList()! : new List<Tag>()
        );
    }

    internal static NewsEntity ToEntity(this Public.Domain.News domain)
    {
        return new NewsEntity()
        {
            Id = domain.Id,
            Headline = domain.Headline,
            Content = domain.Content,
            DatePublished = domain.DatePublished,
            AuthorId = domain.AuthorId,
            CategoryId = domain.CategoryId,
            Tags = domain.Tags!.Select(_ => _.ToEntity()).ToList(),
        };
    }
}