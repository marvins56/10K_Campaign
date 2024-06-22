using System.Net;

namespace FSH.Starter.Application.Common.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message)
        : base(message, null, HttpStatusCode.NotFound)
    {
    }

    public class DuplicateAccountException : Exception
    {
        public DuplicateAccountException(string accountName)
            : base($"An account with the name '{accountName}' already exists.")
        {
        }
    }

    public class DuplicateFundraiserException : Exception
    {
        public DuplicateFundraiserException(string accountName)
            : base($"A member with the email '{accountName}' already exists.")
        {
        }
    }
    public class ResultExistsException : Exception
    {
        public ResultExistsException(string accountName)
            : base($"Result '{accountName}' already exists.")
        {
        }
    }
}
