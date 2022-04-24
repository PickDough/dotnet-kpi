using MMS.News.API.Models;
using MMS.News.BLL.Public.Domain;

namespace MMS.News.API.Mappers;

public static class AuthorMapper
{
    public static AuthorModel ToModel(this Author author)
    {
        return new AuthorModel(
            author.Id,
            author.FirstName,
            author.LastName,
            author.AuthorsNews?.Select(_ => _.ToModel()).ToList()
        );
    }

    public static Author ToDomain(this AuthorModel author)
    {
        return new Author(
            author.Id,
            author.FirstName,
            author.LastName,
            author.AuthorsNews?.Select(_ => _.ToDomain()).ToList()
        );
    }
}