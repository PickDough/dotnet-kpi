namespace MMS.News.DAL.Entities;

public class NewsEntity: Entity<int>
{
    public string Headline { get; set; }
    public string Content { get; set; }
    public DateTime DatePublished { get; set; }
    
    public int AuthorID { get; set; }
    public AuthorEntity Author { get; set; }
    
    public int CategoryID { get; set; }
    public CategoryEntity Category { get; set; }
    
    public List<TagEntity> Tags { get; set; }
}