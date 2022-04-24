using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Public.Entities;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.DAL.Internal.Repositories;

internal class TagsRepository: BaseRepository<int, TagEntity>, ITagsRepository
{
    public TagsRepository(DbContext context) : base(context)
    {
    }
}