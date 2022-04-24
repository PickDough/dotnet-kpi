using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Public.Entities;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.DAL.Internal.Repositories;

internal class NewsRepository: BaseRepository<int, NewsEntity>, INewsRepository
{
    public NewsRepository(DbContext context) : base(context)
    {
    }

    protected override IEnumerable<NewsEntity> WithInclude()
    {
        return Set
            .Include(news => news.Author)
            .Include(news => news.Category)
            .Include(news => news.Tags);
    }
}