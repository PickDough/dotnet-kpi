using MMS.News.BLL.Internal.Mappers;
using MMS.News.BLL.Public.Domain;
using MMS.News.BLL.Public.Services;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.BLL.Internal.Services;

internal class CategoryService: ICategoryService
{
    private ICategoriesRepository _categoriesRepository;

    public CategoryService(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public Category? Get(int id)
    {
        return _categoriesRepository.Get(id).ToDomain();
    }

    public IEnumerable<Category> GetAll()
    {
        return _categoriesRepository.GetAll().Select(_ => _.ToDomain())!;
    }
}