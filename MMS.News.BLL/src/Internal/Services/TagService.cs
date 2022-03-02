using MMS.News.BLL.Internal.Mappers;
using MMS.News.BLL.Public.Domain;
using MMS.News.BLL.Public.Services;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.BLL.Internal.Services;

public class TagService: ITagService
{
    private ITagsRepository _tagsRepository;

    public TagService(ITagsRepository tagsRepository)
    {
        _tagsRepository = tagsRepository;
    }

    public Tag? Get(int id)
    {
        return _tagsRepository.Get(id).ToDomain();
    }

    public IEnumerable<Tag> GetAll()
    {
        return _tagsRepository.GetAll().Select(_ => _.ToDomain())!;
    }
}