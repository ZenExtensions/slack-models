using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    /// <summary>
    /// Represents a slack message
    /// </summary>
    /// <param name="Text">
    ///     The usage of this field changes depending on whether you're using blocks or not. 
    ///     If you are, this is used as a fallback string to display in notifications. 
    ///     If you aren't, this is the main body text of the message. It can be formatted as plain text, or with mrkdwn. 
    ///     This field is not enforced as required when using blocks, however it is highly recommended that you include it as the aforementioned fallback.
    /// </param>
    /// <param name="ResponseType">
    ///     Represents wheter message should only be visible to the user or for entire channel
    /// </param>
    /// <param name="Username">
    ///     The username to display in the message. This will override the default username of the app.
    /// </param>
    /// <param name="IconEmoji">
    ///     The emoji to use as the icon for this message. Overrides <see cref="IconUrl"/>. 
    /// </param>
    /// <param name="IconUrl">
    ///     The URL to an image to use as the icon for this message. 
    /// </param>
    public sealed record class Message(
        [property: JsonPropertyName("text")]
        string? Text = null,
        [property: JsonPropertyName("response_type")]
        string? ResponseType = ResponseType.EPHEMERAL,
        [property: JsonPropertyName("username")]
        string? Username = null,
        [property: JsonPropertyName("icon_emoji")]
        string? IconEmoji = null,
        [property: JsonPropertyName("icon_url")]
        string? IconUrl = null
    )
    {

        /// <summary>
        /// Representst the attachments of the slack message
        /// </summary>
        [JsonPropertyName("attachments")]
        public List<Attachment>? Attachments { get; private set; }
        /// <summary>
        /// Adds an attachment to the message
        /// </summary>
        /// <param name="attachment">Instance of <see cref="Attachment"/></param>
        /// <returns>Instance of current <see cref="Message"/></returns>
        public Message AddAttachment([NotNull] Attachment attachment)
        {
            ArgumentNullException.ThrowIfNull(attachment, nameof(attachment));
            Attachments ??= new List<Attachment>();
            Attachments.Add(attachment);
            return this;
        }
    }
}