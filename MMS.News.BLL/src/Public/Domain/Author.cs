namespace MMS.News.BLL.Public.Domain;

public class Author
{
    public int ID { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<News>? AuthorsNews { get; set; }
}