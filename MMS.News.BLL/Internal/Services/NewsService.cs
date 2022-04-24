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

    public Public.Domain.News? Get(int Id)
    {
        return _newsRepository.Get(Id).ToDomain();
    }

    public void Add(Public.Domain.News news)
    {
        _newsRepository.Add(news.ToEntity());
    }

    public void Update(Public.Domain.News news)
    {
        _newsRepository.Update(news.ToEntity());
    }

    public void Delete(int Id)
    {
        _newsRepository.Remove(Id);
    }

    public IEnumerable<Public.Domain.News> GetLatestNews(DateTime dateTime)
    {
        return _newsRepository
            .GetAllWhere(n => n.DatePublished > dateTime)
            .Select(_ => _.ToDomain())!;
    }

    public IEnumerable<Public.Domain.News> GetAuthorsNews(int authorId)
    {
        return _newsRepository
            .GetAllWhere(n => n.AuthorId == authorId)
            .OrderBy(n => n.DatePublished)
            .Select(_ => _.ToDomain())!;
    }

    public IEnumerable<Public.Domain.News> GetNewsByCategory(string category)
    {
        return _newsRepository
            .GetAllWhere(n => n.Category?.Name == category)
            .OrderBy(n => n.DatePublished)
            .Select(_ => _.ToDomain())!;
    }

    public IEnumerable<Public.Domain.News> GetNewsByTags(IEnumerable<int> tagIds)
    {
        var news = new List<Public.Domain.News>();
        foreach (var tagId in tagIds)
        {
            news.AddRange
            (
                _newsRepository
                    .GetAllWhere(n => news.All(_ => _.Id != tagId) && n.Tags!.Any(_ => _.Id == tagId))
                    .Select(_ => _.ToDomain())!
            );
        }

        return news.OrderBy(n => n.DatePublished);
    }
}