using Microsoft.EntityFrameworkCore;

namespace MMS.News.DAL.Public.Entities;

public class AuthorEntity : Entity<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int HashedPassword { get; set; }

    public List<NewsEntity>? AuthorsNews { get; set; }
}