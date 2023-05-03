using System.Runtime.Serialization;

namespace FansoftEcommerce.Domain.Common;

public class DomainException : Exception
{
    public DomainException(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; private set; }
    

    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}