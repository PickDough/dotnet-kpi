using Microsoft.EntityFrameworkCore;

namespace MMS.News.DAL.Public.Entities;

public class AuthorEntity : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public int HashedPassword { get; set; }

    public List<NewsEntity> AuthorsNews { get; set; }
}