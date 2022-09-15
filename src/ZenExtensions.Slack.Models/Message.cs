using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    public sealed record class Message(
        [property: JsonPropertyName("text")]
        string? Text = null,
        [property: JsonPropertyName("response_type")]
        ResponseType? ResponseType = ResponseType.Ephemeral,
        [property: JsonPropertyName("username")]
        string? Username = null,
        [property: JsonPropertyName("icon_emoji")]
        string? IconEmoji = null,
        [property: JsonPropertyName("icon_url")]
        string? IconUrl = null
    )
    {
        [JsonPropertyName("attachments")]
        public List<Attachment>? Attachments { get; private set; }
        public Message AddField([NotNull] Attachment attachment)
        {
            ArgumentNullException.ThrowIfNull(attachment, nameof(attachment));
            Attachments ??= new List<Attachment>();
            Attachments.Add(attachment);
            return this;
        }
    }
}