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
        [property: JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Text = null,
        [property: JsonPropertyName("response_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? ResponseType = ResponseType.EPHEMERAL,
        [property: JsonPropertyName("username"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Username = null,
        [property: JsonPropertyName("icon_emoji"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? IconEmoji = null,
        [property: JsonPropertyName("icon_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? IconUrl = null
    )
    {

        /// <summary>
        /// Representst the attachments of the slack message
        /// </summary>
        [JsonPropertyName("attachments"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Attachment>? Attachments { get; private set; }
        /// <summary>
        /// Adds an attachment to the message
        /// </summary>
        /// <param name="attachment">Instance of <see cref="Attachment"/></param>
        /// <returns>Instance of current <see cref="Message"/></returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="attachment"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when there are already 10 attachments attached with message</exception>
        public Message AddAttachment([NotNull] Attachment attachment)
        {
            ArgumentNullException.ThrowIfNull(attachment, nameof(attachment));
            Attachments ??= new List<Attachment>();
            if (Attachments.Count >= 10)
            {
                throw new InvalidOperationException("Cannot add more than 10 attachments to a message");
            }
            Attachments.Add(attachment);
            return this;
        }

        private static Message colorMessage(string text, string color)
        {
            return new Message()
                .AddAttachment(
                    new Attachment(
                        Text: text,
                        Color: color
                    )
                );
        }

        /// <summary>
        /// Returns a new error message
        /// </summary>
        /// <param name="text">text body of message</param>
        /// <returns>new instance of <see cref="Message"/></returns>
        public static Message ErrorMessage(string text)
        {
            return colorMessage(text, "#F44336");
        }

        /// <summary>
        /// Returns a new info message
        /// </summary>
        /// <param name="text">text body of message</param>
        /// <returns>new instance of <see cref="Message"/></returns>
        public static Message InfoMessage(string text)
        {
            return colorMessage(text, "#29B6F6");
        }

        /// <summary>
        /// Returns a new warning message
        /// </summary>
        /// <param name="text">text body of message</param>
        /// <returns>new instance of <see cref="Message"/></returns>
        public static Message WarningMessage(string text)
        {
            return colorMessage(text, "#FFEE58");
        }

        /// <summary>
        /// Returns a new success message
        /// </summary>
        /// <param name="text">text body of message</param>
        /// <returns>new instance of <see cref="Message"/></returns>
        public static Message SuccessMessage(string text)
        {
            return colorMessage(text, "#00C853");
        }
    }
}