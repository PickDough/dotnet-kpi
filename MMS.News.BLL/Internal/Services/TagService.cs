using MMS.News.BLL.Internal.Mappers;
using MMS.News.BLL.Public.Domain;
using MMS.News.BLL.Public.Services;
using MMS.News.DAL.Public.Repositories;
using MMS.News.DAL.Public.UOF;

namespace MMS.News.BLL.Internal.Services;

public class TagService: ITagService
{
    private readonly ITagsRepository _tagsRepository;

    public TagService(IUnitOfWork unitOfWork)
    {
        _tagsRepository = unitOfWork.TagsRepository;
    }

    public Tag? Get(int Id)
    {
        return _tagsRepository.Get(Id).ToDomain();
    }

    public IEnumerable<Tag> GetAll()
    {
        return _tagsRepository.GetAll().Select(_ => _.ToDomain())!;
    }
}