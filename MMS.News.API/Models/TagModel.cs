namespace MMS.News.API.Models;

public class TagModel
{
    public TagModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}