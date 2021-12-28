﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shamyr.AspNetCore;

public static class Json
{
    public static JsonSerializerOptions DefaultSerializerOptions => SetupDefaultSerializerOptions(new());

    public static JsonSerializerOptions SetupDefaultSerializerOptions(JsonSerializerOptions opt)
    {
        opt.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opt.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        opt.Converters.Add(new JsonStringEnumConverter());

        return opt;
    }
}
