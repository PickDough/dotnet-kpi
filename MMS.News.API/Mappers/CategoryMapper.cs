using MMS.News.API.Models;
using MMS.News.BLL.Public.Domain;

namespace MMS.News.API.Mappers;

public static class CategoryMapper
{
    public static CategoryModel ToModel(this Category category)
    {
        return new CategoryModel(
            category.Id,
            category.Name
        );
    }

    public static Category ToDomain(this CategoryModel category)
    {
        return new Category(
            category.Id,
            category.Name
        );
    }
}