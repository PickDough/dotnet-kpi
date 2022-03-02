using MMS.News.BLL.Public.Domain;

namespace MMS.News.BLL.Public.Services;

public interface ITagService
{
    Tag? Get(int id);
    IEnumerable<Tag> GetAll();
}