using MMS.News.BLL.Public.Domain;

namespace MMS.News.BLL.Public.Services;

public interface IAuthorService
{
    Author? Get(int id);
    IEnumerable<Author> GetAll();

    void Signup(AuthorSignUp authorSignUp);
    void Login(AuthorLogin authorSignUp);
}