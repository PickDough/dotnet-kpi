using MMS.News.DAL.Public.Repositories;

namespace MMS.News.DAL.Public.UOF;

public interface IUnitOfWork
{
    public IAuthorsRepository AuthorsRepository { get; }
    public INewsRepository NewsRepository { get; }
    public ICategoriesRepository CategoriesRepository { get; }
    public ITagsRepository TagsRepository { get; }
}