using System.Runtime.Serialization;

namespace FSH.Starter.Application.Common.Exceptions;
[Serializable]
internal class UpdateFailureException : Exception
{
    public UpdateFailureException()
    {
    }

    public UpdateFailureException(string? message) : base(message)
    {
    }

    public UpdateFailureException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UpdateFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}