using MMS.News.BLL.Public.Domain;

namespace MMS.News.BLL.Public.Services;

public interface ICategoryService
{
    Category Get(int id);
    IEnumerable<Category> GetAll();
}