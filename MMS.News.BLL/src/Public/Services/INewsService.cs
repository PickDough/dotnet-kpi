using MMS.News.BLL.Public.Domain;

namespace MMS.News.BLL.Public.Services;

public interface INewsService
{
    Domain.News Get(int id);
    void Add(Domain.News news);
    void Update(Domain.News news);
    void Delete(int id);
    
    IEnumerable<Domain.News> GetLatestNews(DateTime dateTime);
    IEnumerable<Domain.News> GetAuthorsNews(int authorId);
    IEnumerable<Domain.News> GetNewsByCategory(string category);
    IEnumerable<Domain.News> GetNewsByTags(IEnumerable<Tag> tags);
}