using Microsoft.Extensions.DependencyInjection;
using MMS.News.BLL.Internal.Services;
using MMS.News.BLL.Public.Services;

namespace MMS.News.BLL.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthorService, AuthorService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<INewsService, NewsService>();
        services.AddTransient<ITagService, TagService>();

        return services;
    }
}