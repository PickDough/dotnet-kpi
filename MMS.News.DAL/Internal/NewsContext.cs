using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MMS.News.DAL.Public.Entities;

namespace MMS.News.DAL.Internal;

public class NewsContext: DbContext
{
    public DbSet<AuthorEntity> Authors { get; set; } = null!;
    public DbSet<NewsEntity> News { get; set; } = null!;
    public DbSet<TagEntity> Tags { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;

    public NewsContext(DbContextOptions<NewsContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
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