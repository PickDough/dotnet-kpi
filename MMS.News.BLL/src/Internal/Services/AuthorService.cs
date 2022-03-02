using MMS.News.BLL.Internal.Mappers;
using MMS.News.BLL.Public.Domain;
using MMS.News.BLL.Public.Exception;
using MMS.News.BLL.Public.Services;
using MMS.News.DAL.Public.Entities;
using MMS.News.DAL.Public.Repositories;

namespace MMS.News.BLL.Internal.Services;

internal class AuthorService : IAuthorService
{
    private IAuthorsRepository _authorsRepository;

    public AuthorService(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public Author? Get(int id)
    {
        return _authorsRepository.Get(id).ToDomain();
    }

    public IEnumerable<Author> GetAll()
    {
        return _authorsRepository.GetAll().Select(_ => _.ToDomain())!;
    }

    public void Signup(AuthorSignUp authorSignUp)
    {
        if (_authorsRepository.GetWhere(a => a.Email == authorSignUp.Email) is not null)
        {
            throw new EmailAlreadyExistsException(authorSignUp.Email);
        }

        _authorsRepository.Add(new AuthorEntity()
        {
            Email = authorSignUp.Email,
            FirstName = authorSignUp.FirstName,
            LastName = authorSignUp.LastName,
            HashedPassword = authorSignUp.Password.GetHashCode()
        });
    }

    public void Login(AuthorLogin authorSignUp)
    {
        var author = _authorsRepository.GetWhere(a => a.Email == authorSignUp.Email &&
                                                 a.HashedPassword == authorSignUp.Password.GetHashCode());
 
        if (author is null)
            throw new InvalidCredentialsException();
    }
}