using System.Collections.Generic;

namespace Shamyr.AspNetCore.HttpErrors;

public record HttpErrorResponseModel
{
    public string? Message { get; init; }
    public string? Code { get; init; } = default!;
    public ICollection<ErrorModel>? Errors { get; init; }
    public KeyValuePair<string, object>[]? Features { get; init; }
}
