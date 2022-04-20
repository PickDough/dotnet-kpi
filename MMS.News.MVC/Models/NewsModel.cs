namespace MMS.News.MVC.Models;

public class NewsModel
{
    public int ID { get; set; }

    public string Headline { get; set; }
    public string Content { get; set; }
    public DateTime DatePublished { get; set; }

    public int AuthorId { get; set; }
    public AuthorModel? Author { get; set; }

    public int CategoryId { get; set; }
    public CategoryModel? Category { get; set; }

    public List<TagModel>? Tags { get; set; }
}