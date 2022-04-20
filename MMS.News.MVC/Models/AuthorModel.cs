namespace MMS.News.MVC.Models;

public class AuthorModel
{
    public int ID { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<NewsModel>? AuthorsNews { get; set; }
}