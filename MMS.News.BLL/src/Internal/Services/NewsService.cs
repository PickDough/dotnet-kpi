using MMS.News.BLL.Internal.Mappers;
using MMS.News.BLL.Public.Domain;
using MMS.News.BLL.Public.Services;
using MMS.News.DAL.Public.Repositories;
using MMS.News.DAL.Public.UOF;

namespace MMS.News.BLL.Internal.Services;

internal class NewsService: INewsService
{
    private readonly INewsRepository _newsRepository;

    public NewsService(IUnitOfWork unitOfWork)
    {
        _newsRepository = unitOfWork.NewsRepository;
    }

    public Public.Domain.News? Get(int id)
    {
        return _newsRepository.Get(id).ToDomain();
    }

    public void Add(Public.Domain.News news)
    {
        _newsRepository.Add(news.ToEntity());
    }

    public void Update(Public.Domain.News news)
    {
        _newsRepository.Update(news.ToEntity());
    }

    public void Delete(int id)
    {
        _newsRepository.Remove(id);
    }

    public IEnumerable<Public.Domain.News> GetLatestNews(DateTime dateTime)
    {
        return _newsRepository
            .GetAllWhere(n => n.DatePublished > dateTime)
            .Select(_ => _.ToDomain())!;
    }

    public IEnumerable<Public.Domain.News> GetAuthorsNews(int authorId, int limit)
    {
        return _newsRepository
            .GetAllWhere(n => n.AuthorID > authorId)
            .OrderBy(n => n.DatePublished)
            .Take(limit)
            .Select(_ => _.ToDomain())!;
    }

    public IEnumerable<Public.Domain.News> GetNewsByCategory(string category, int limit)
    {
        return _newsRepository
            .GetAllWhere(n => n.Category.Name == category)
            .OrderBy(n => n.DatePublished)
            .Take(limit)
            .Select(_ => _.ToDomain())!;
    }

    public IEnumerable<Public.Domain.News> GetNewsByTags(IEnumerable<Tag> tags, int limit)
    {
        var news = new List<Public.Domain.News>();
        foreach (var tag in tags)
        {
            news.AddRange
            (
                _newsRepository
                    .GetAllWhere(n => news.All(_ => _.ID != n.ID) && n.Tags.Any(_ => _.ID == tag.ID))
                    .Take(limit)
                    .Select(_ => _.ToDomain())!
            );
        }

        return news.OrderBy(n => n.DatePublished);
    }
}