using System.Runtime.Serialization;

namespace MMS.News.BLL.Public.Exception;

public class EmailAlreadyExistsException: System.Exception
{
    public EmailAlreadyExistsException(string email)
    {
        Email = email;
    }

    protected EmailAlreadyExistsException(SerializationInfo info, StreamingContext context, string email) : base(info, context)
    {
        Email = email;
    }

    public EmailAlreadyExistsException(string? message, string email) : base(message)
    {
        Email = email;
    }

    public EmailAlreadyExistsException(string? message, System.Exception? innerException, string email) : base(message, innerException)
    {
        Email = email;
    }

    public string Email { get; }
}