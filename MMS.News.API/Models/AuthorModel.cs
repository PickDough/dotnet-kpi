namespace MMS.News.API.Models;

public class AuthorModel
{
    public AuthorModel(int id, string firstName, string lastName, List<NewsModel>? authorsNews)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        AuthorsNews = authorsNews;
    }

    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public List<NewsModel>? AuthorsNews { get; }
}