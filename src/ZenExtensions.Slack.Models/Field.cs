using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models
{
    public sealed record class Field(
        [property: JsonPropertyName("title")]
        string? Title, 
        [property: JsonPropertyName("value")]
        string? Value, 
        [property: JsonPropertyName("short")]
        bool Short = true
    );
}