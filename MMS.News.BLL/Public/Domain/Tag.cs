namespace MMS.News.BLL.Public.Domain;

public class Tag
{
    public Tag(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    
    public string Name { get; set; }
}