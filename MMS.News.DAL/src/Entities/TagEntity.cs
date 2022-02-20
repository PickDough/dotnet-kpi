namespace MMS.News.DAL.Entities;

public class TagEntity: Entity<int>
{
    public string Name { get; set; }
    
    public List<NewsEntity> News { get; set; }
}