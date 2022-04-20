using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMS.News.DAL.Internal.UOF;
using MMS.News.DAL.Public.UOF;

namespace MMS.News.DAL.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<NewsContext>(
            options => options.UseSqlite(
                config.GetConnectionString("NewsDb") ?? throw new InvalidOperationException()
                )
            );

        return services;
    }
}