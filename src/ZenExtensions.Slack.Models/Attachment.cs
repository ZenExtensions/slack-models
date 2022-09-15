using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models
{
    public sealed record class Attachment(
        [property: JsonPropertyName("text")]
        string? Text = null,
        [property: JsonPropertyName("fallback")]
        string? Fallback = null,
        [property: JsonPropertyName("footer")]
        string? Footer = null,
        [property: JsonPropertyName("color")]
        string? Color = null,
        [property: JsonPropertyName("image_url")]
        string? ImageUrl = null,
        [property: JsonPropertyName("pretext")]
        string? PreText = null,
        [property: JsonPropertyName("thumb_url")]
        string? ThumbUrl = null,
        [property: JsonPropertyName("title")]
        string? Title = null,
        [property: JsonPropertyName("title_link")]
        string? TitleLink = null,
        [property: JsonPropertyName("ts")]
        string? Ts = null,
        [property: JsonPropertyName("author_name")]
        string? AuthorName = null,
        [property: JsonPropertyName("author_link")]
        string? AuthorLink = null
    )
    {
        [JsonPropertyName("fields")]
        public List<Field>? Fields { get; private set; }
        public Attachment AddField([NotNull] string title, [NotNull] string value, bool @short = true)
        {
            ArgumentNullException.ThrowIfNull(title, nameof(title));
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            Fields ??= new List<Field>();
            Fields.Add(
                new Field(Title: title, Value: value, Short: @short)
            );
            return this;
        }

        public Attachment AddField([NotNull] Field field)
        {
            ArgumentNullException.ThrowIfNull(field, nameof(field));
            Fields ??= new List<Field>();
            Fields.Add(field);
            return this;
        }
    }
}