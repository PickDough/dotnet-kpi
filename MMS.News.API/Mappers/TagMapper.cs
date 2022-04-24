using MMS.News.API.Models;
using MMS.News.BLL.Public.Domain;

namespace MMS.News.API.Mappers;

public static class TagMapper
{
    public static TagModel ToModel(this Tag tag)
    {
        return new TagModel(
            tag.Id,
            tag.Name
        );
    }

    public static Tag ToDomain(this TagModel tag)
    {
        return new Tag(
            tag.Id,
            tag.Name
        );
    }
}