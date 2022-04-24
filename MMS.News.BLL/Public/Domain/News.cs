namespace MMS.News.BLL.Public.Domain;

public class News
{
    public News(int id, string headline, string content, DateTime datePublished, int authorId, Author? author, int categoryId, Category? category, List<Tag>? tags)
    {
        Id = id;
        Headline = headline;
        Content = content;
        DatePublished = datePublished;
        AuthorId = authorId;
        Author = author;
        CategoryId = categoryId;
        Category = category;
        Tags = tags;
    }

    public int Id { get; set; }
    
    public string Headline { get; set; }
    public string Content { get; set; }
    public DateTime DatePublished { get; set; }
    
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public List<Tag>? Tags { get; set; }
}