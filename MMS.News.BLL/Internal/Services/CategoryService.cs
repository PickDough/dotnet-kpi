using MMS.News.BLL.Internal.Mappers;
using MMS.News.BLL.Public.Domain;
using MMS.News.BLL.Public.Services;
using MMS.News.DAL.Public.Repositories;
using MMS.News.DAL.Public.UOF;

namespace MMS.News.BLL.Internal.Services;

internal class CategoryService: ICategoryService
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _categoriesRepository = unitOfWork.CategoriesRepository;
    }

    public Category? Get(int Id)
    {
        return _categoriesRepository.Get(Id).ToDomain();
    }

    public IEnumerable<Category> GetAll()
    {
        return _categoriesRepository.GetAll().Select(_ => _.ToDomain())!;
    }
}