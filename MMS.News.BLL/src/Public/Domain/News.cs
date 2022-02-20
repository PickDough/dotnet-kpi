namespace MMS.News.BLL.Public.Domain;

public class News
{
    public int ID { get; set; }
    
    public string Headline { get; set; }
    public string Content { get; set; }
    public DateTime DatePublished { get; set; }
    
    public int AuthorID { get; set; }
    public Author? Author { get; set; }
    
    public int CategoryID { get; set; }
    public Category? Category { get; set; }
    
    public List<Tag>? Tags { get; set; }
}