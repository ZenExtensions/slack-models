using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    /// <summary>
    /// Represents a field of slack message
    /// </summary>
    /// <param name="Title">
    ///     Shown as a bold heading displayed in the field object. It cannot contain markup and will be escaped for you.
    /// </param>
    /// <param name="Value">
    ///     The text value displayed in the field object
    /// </param>
    /// <param name="Short">
    ///     Indicates whether the field object is short enough to be displayed side-by-side with other field objects. Defaults to false.
    /// </param>
    public sealed record class Field(
        [property: JsonPropertyName("title")]
        string? Title, 
        [property: JsonPropertyName("value")]
        string? Value, 
        [property: JsonPropertyName("short")]
        bool Short = true
    );
}