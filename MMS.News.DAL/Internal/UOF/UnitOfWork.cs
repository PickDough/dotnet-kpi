using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Internal.Repositories;
using MMS.News.DAL.Public.Repositories;
using MMS.News.DAL.Public.UOF;

namespace MMS.News.DAL.Internal.UOF;

internal class UnitOfWork: IUnitOfWork
{
    public UnitOfWork(NewsContext context)
    {
        AuthorsRepository = new AuthorsRepository(context);
        NewsRepository = new NewsRepository(context);
        CategoriesRepository = new CategoriesRepository(context);
        TagsRepository = new TagsRepository(context);
    }
    
    public IAuthorsRepository AuthorsRepository { get; }
    public INewsRepository NewsRepository { get; }
    public ICategoriesRepository CategoriesRepository { get; }
    public ITagsRepository TagsRepository { get; }
}