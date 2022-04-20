using MMS.News.MVC.Models;

namespace MMS.News.MVC.Mappers;

public static class NewsMapper
{
    public static NewsModel ToModel(BLL.Public.Domain.News domain)
    {
        return new NewsModel()
        {
            ID = domain.ID,
            AuthorId = domain.AuthorId,
            Author = domain.Author?.ToModel(),
            CategoryId = domain.CategoryId,
            Category = domain.Category?.ToModel(),
            Content = domain.Content,
            DatePublished = domain.DatePublished,
            Headline = domain.Headline,
            Tags = domain.Tags?.Select(_ => _.ToModel()),
        };
    }
    
    public static BLL.Public.Domain.News ToDomain(NewsModel model)
    {
        return new BLL.Public.Domain.News()
        {
            ID = model.ID,
            AuthorId = model.AuthorId,
            Author = model.Author?.ToDomain(),
            CategoryId = model.CategoryId,
            Category = model.Category?.ToDomain(),
            Content = model.Content,
            DatePublished = model.DatePublished,
            Headline = model.Headline,
            Tags = model.Tags?.Select(_ => _.ToDomain()),
        };
    }
}