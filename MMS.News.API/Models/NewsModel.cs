namespace MMS.News.API.Models;

public class NewsModel
{
    public NewsModel(int id, string headline, string content, DateTime datePublished, int authorId, AuthorModel? author, int categoryId, CategoryModel? category, List<TagModel>? tags)
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

    public int Id { get; }

    public string Headline { get; }
    public string Content { get; }
    public DateTime DatePublished { get; }

    public int AuthorId { get; set; }
    public AuthorModel? Author { get; }

    public int CategoryId { get; }
    public CategoryModel? Category { get; }

    public List<TagModel>? Tags { get; }
}