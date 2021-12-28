using System;

namespace Shamyr.Exceptions;

public class ConflictException: Exception, IErrorCodeException
{
    public ConflictException() { }

    public ConflictException(string message)
      : base(message) { }

    public ConflictException(string message, Exception innerException)
      : base(message, innerException) { }

    public string? ErrorCode { get; init; }
}
