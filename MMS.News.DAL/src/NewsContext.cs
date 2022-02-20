using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Entities;

namespace MMS.News.DAL;

public class NewsContext: DbContext
{
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<NewsEntity> News { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    
    public string DbPath { get; }
    
    public NewsContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "news.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}