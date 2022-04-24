using MMS.News.API.Models;

namespace MMS.News.API.Mappers;

public static class NewsMapper
{
    public static NewsModel ToModel(this BLL.Public.Domain.News news)
    {
        return new NewsModel(
            news.Id,
            news.Headline,
            news.Content,
            news.DatePublished,
            news.AuthorId,
            news.Author?.ToModel(),
            news.CategoryId,
            news.Category?.ToModel(),
            news.Tags?.Select(_ => _.ToModel()).ToList()
        );
    }

    public static BLL.Public.Domain.News ToDomain(this NewsModel news)
    {
        return new BLL.Public.Domain.News(
            news.Id,
            news.Headline,
            news.Content,
            news.DatePublished,
            news.AuthorId,
            news.Author?.ToDomain(),
            news.CategoryId,
            news.Category?.ToDomain(),
            news.Tags?.Select(_ => _.ToDomain()).ToList()
        );
    }
}