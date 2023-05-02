using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace FansoftEcommerce.Application.Common;

public class ValidationBehaviorException : ValidationException
{
    public ValidationBehaviorException(string message) : base(message)
    {
    }

    public ValidationBehaviorException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
    {
    }

    public ValidationBehaviorException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
    {
    }

    public ValidationBehaviorException(IEnumerable<ValidationFailure> errors) : base(errors)
    {
    }

    public ValidationBehaviorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}