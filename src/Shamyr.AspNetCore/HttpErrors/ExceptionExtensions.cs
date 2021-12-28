using System;
using Shamyr.Exceptions;

namespace Shamyr.AspNetCore.HttpErrors;

public static class ExceptionExtensions
{
    public static HttpErrorResponseModel ToHttpResponseModel(this Exception exception)
    {
        if (exception is null)
            throw new ArgumentNullException(nameof(exception));

        string? code = (exception as IErrorCodeException)?.ErrorCode;

        return new HttpErrorResponseModel
        {
            Message = exception.GetType().Name,
            Code = code,
            Errors = new ErrorModel[]
            {
                new ErrorModel
                {
                    Name = exception.GetType().Name,
                    Code = code,
                    Message = exception.Message
                }
            }
        };
    }
}
