namespace MMS.News.API.Models;

public class CategoryModel
{
    public CategoryModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}