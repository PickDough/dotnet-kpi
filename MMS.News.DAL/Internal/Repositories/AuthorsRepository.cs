using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Public.Entities;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.DAL.Internal.Repositories;

internal class AuthorsRepository: BaseRepository<int, AuthorEntity>, IAuthorsRepository
{
    internal AuthorsRepository(DbContext context) : base(context)
    {
    }

    protected override IEnumerable<AuthorEntity> WithInclude()
    {
        return Set.Include(author => author.AuthorsNews);
    }
}