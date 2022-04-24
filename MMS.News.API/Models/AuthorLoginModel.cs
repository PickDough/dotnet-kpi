namespace MMS.News.API.Models;

public class AuthorLoginModel
{
    public AuthorLoginModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get;}
    public string Password { get;}
}