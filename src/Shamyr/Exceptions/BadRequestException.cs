using System;

namespace Shamyr.Exceptions;

public class BadRequestException: Exception, IErrorCodeException
{
    public BadRequestException() { }

    public BadRequestException(string message)
      : base(message) { }

    public BadRequestException(string message, Exception innerException)
      : base(message, innerException) { }

    public string? ErrorCode { get; init; }
}
