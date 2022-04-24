namespace MMS.News.DAL.Public.Entities;

public class NewsEntity: Entity<int>
{
    public string Headline { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime DatePublished { get; set; }
    
    public int AuthorId { get; set; }
    public AuthorEntity? Author { get; set; }
    
    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    
    public List<TagEntity>? Tags { get; set; }
}