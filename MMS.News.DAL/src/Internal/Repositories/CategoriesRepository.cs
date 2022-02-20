using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Public.Entities;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.DAL.Internal.Repositories;

internal class CategoriesRepository: BaseRepository<int, CategoryEntity>, ICategoriesRepository
{
    public CategoriesRepository(DbContext context) : base(context)
    {
    }
}