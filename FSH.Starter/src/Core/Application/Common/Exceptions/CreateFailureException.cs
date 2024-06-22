using System.Runtime.Serialization;

namespace FSH.Starter.Application.Common.Exceptions;
[Serializable]
internal class CreateFailureException : Exception
{
    public CreateFailureException()
    {
    }

    public CreateFailureException(string? message) : base(message)
    {
    }

    public CreateFailureException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CreateFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}