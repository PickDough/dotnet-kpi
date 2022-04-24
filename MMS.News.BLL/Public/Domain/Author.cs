namespace MMS.News.BLL.Public.Domain;

public class Author
{
    public Author(int id, string firstName, string lastName, List<News>? authorsNews)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        AuthorsNews = authorsNews;
    }

    public int Id { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<News>? AuthorsNews { get; set; }
}