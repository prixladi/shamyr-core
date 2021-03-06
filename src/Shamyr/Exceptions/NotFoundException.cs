using System;

namespace Shamyr.Exceptions;

public class NotFoundException: Exception, IErrorCodeException
{
    public NotFoundException() { }

    public NotFoundException(string message)
      : base(message) { }

    public NotFoundException(string message, Exception innerException)
      : base(message, innerException) { }

    public string? ErrorCode { get; init; }
}
