namespace MMS.News.DAL.Entities;

public class AuthorEntity: Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    
    public List<NewsEntity> AuthorsNews { get; set; }
}