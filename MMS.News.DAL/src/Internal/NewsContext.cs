using Microsoft.EntityFrameworkCore;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.DAL;

public class NewsContext: DbContext
{
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<NewsEntity> News { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    public NewsContext(DbContextOptions<NewsContext> options) : base(options)
    {
        
    }
    
    // public string DbPath { get; }
    //
    // public NewsContext()
    // {
    //     DbPath = "news.db";
    // }
    //
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite($"Data Source={DbPath}");
}