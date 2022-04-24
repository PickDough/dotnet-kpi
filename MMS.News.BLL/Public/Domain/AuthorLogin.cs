namespace MMS.News.BLL.Public.Domain;

public class AuthorLogin
{
    public AuthorLogin(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}