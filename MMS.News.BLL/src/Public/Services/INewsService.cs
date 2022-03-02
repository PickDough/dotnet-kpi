using MMS.News.BLL.Public.Domain;

namespace MMS.News.BLL.Public.Services;

public interface INewsService
{
    public const int TagsLimit = 5;
    public const int NewsLimit = 20;
    Domain.News? Get(int id);
    void Add(Domain.News news);
    void Update(Domain.News news);
    void Delete(int id);
    
    IEnumerable<Domain.News> GetLatestNews(DateTime dateTime);
    IEnumerable<Domain.News> GetAuthorsNews(int authorId, int limit = NewsLimit);
    IEnumerable<Domain.News> GetNewsByCategory(string category, int limit = NewsLimit);
    IEnumerable<Domain.News> GetNewsByTags(IEnumerable<Tag> tags, int limit = TagsLimit);
}