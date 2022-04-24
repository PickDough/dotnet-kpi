namespace MMS.News.DAL.Public.Entities;

public class TagEntity: Entity<int>
{
    public string Name { get; set; } = null!;

    public List<NewsEntity>? News { get; set; }
}