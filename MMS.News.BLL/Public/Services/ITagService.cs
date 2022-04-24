using MMS.News.BLL.Public.Domain;

namespace MMS.News.BLL.Public.Services;

public interface ITagService
{
    Tag? Get(int Id);
    IEnumerable<Tag> GetAll();
}