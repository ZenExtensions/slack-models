using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    /// <summary>
    /// Represents an attachment of slack message
    /// </summary>
    /// <param name="Text">
    ///     The main body text of the attachment. It can be formatted as plain text, or with mrkdwn by including it in the mrkdwn_in field. <br/> 
    ///     The content will automatically collapse if it contains 700+ characters or 5+ line breaks, and will display a "Show more..." link to expand the content.
    /// </param>
    /// <param name="Fallback">
    ///     A plain text summary of the attachment used in clients that don't show formatted text (eg. IRC, mobile notifications).
    /// </param>
    /// <param name="Footer">
    ///     Some brief text to help contextualize and identify an attachment. <br/>
    ///     Limited to 300 characters, and may be truncated further when displayed to users in environments with limited screen real estate.
    /// </param>
    /// <param name="FooterIcon">
    ///      valid URL to an image file that will be displayed beside the <see cref="Footer"/> text. Will only work if <see cref="AuthorName"/> is present. We'll render what you provide at 16px by 16px. It's best to use an image that is similarly sized.
    /// </param>
    /// <param name="Color">
    ///     Changes the color of the border on the left side of this attachment from the default gray. 
    ///     Can either be one of good (green), warning (yellow), danger (red), or any hex color code (eg. #439FE0)
    /// </param>
    /// <param name="ImageUrl">
    ///     A valid URL to an image file that will be displayed at the bottom of the attachment. We support GIF, JPEG, PNG, and BMP formats. <br/>
    ///     Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still maintaining the original aspect ratio. Cannot be used with <see cref="ImageUrl"/>.
    /// </param>
    /// <param name="PreText">
    ///     Text that appears above the message attachment block. It can be formatted as plain text, or with mrkdwn by including it in the mrkdwn_in field.
    /// </param>
    /// <param name="ThumbUrl">
    ///     A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP. <br/>
    ///     The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of the image. The file size of the image must also be less than 500 KB. <br/>
    ///     For best results, please use images that are already 75px by 75px.
    /// </param>
    /// <param name="Title">
    ///     Large title text near the top of the attachment
    /// </param>
    /// <param name="TitleLink">
    ///     A valid URL that turns the title text into a hyperlink
    /// </param>
    /// <param name="Ts">
    ///     An integer <a href="https://en.wikipedia.org/wiki/Unix_time">Unix timestamp</a> that is used to related your attachment to a specific time. The attachment will display the additional timestamp value as part of the attachment's footer. <br/>
    ///     Your message's timestamp will be displayed in varying ways, depending on how far in the past or future it is, relative to the present. Form factors, like mobile versus desktop may also transform its rendered appearance.
    /// </param>
    /// <param name="AuthorName">
    ///     Small text used to display the author's name.
    /// </param>
    /// <param name="AuthorLink">
    ///     A valid URL that will hyperlink the <see cref="AuthorName"/> text. Will only work if <see cref="AuthorName"/> is present.
    /// </param>
    /// <param name="AuthorIcon">
    ///     A valid URL that displays a small 16px by 16px image to the left of the <see cref="AuthorName"/> text. Will only work if <see cref="AuthorName"/> is present.
    /// </param>
    public sealed record class Attachment(
        [property: JsonPropertyName("text")]
        string? Text = null,
        [property: JsonPropertyName("fallback")]
        string? Fallback = null,
        [property: JsonPropertyName("footer")]
        string? Footer = null,
        [property: JsonPropertyName("footer")]
        string? FooterIcon = null,
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
        string? AuthorLink = null,
        [property: JsonPropertyName("author_icon")]
        string? AuthorIcon = null
    )
    {
        /// <summary>
        /// An array of field objects that get displayed in a table-like way (See the example above). For best results, include no more than 2-3 field objects.
        /// </summary>
        [JsonPropertyName("fields")]
        public IList<Field>? Fields { get; private set; }
        /// <summary>
        /// Adds a new field to the attachment
        /// </summary>
        /// <param name="title">
        ///     Shown as a bold heading displayed in the field object. It cannot contain markup and will be escaped for you.
        /// </param>
        /// <param name="value">
        ///     The text value displayed in the field object
        /// </param>
        /// <param name="short">
        ///     Indicates whether the field object is short enough to be displayed side-by-side with other field objects. Defaults to false.
        /// </param>
        /// <returns>Instance of current <see cref="Attachment"/></returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="title"/> or <paramref name="value"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when there are already 10 fields in the attachment</exception>
        public Attachment AddField([NotNull] string title, [NotNull] string value, bool @short = true)
        {
            ArgumentNullException.ThrowIfNull(title, nameof(title));
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            Fields ??= new List<Field>();
            if(Fields.Count >= 10)
            {
                throw new InvalidOperationException("Cannot add more than 10 fields to an attachment");
            }
            Fields.Add(
                new Field(Title: title, Value: value, Short: @short)
            );
            return this;
        }
        /// <summary>
        /// Adds a new field to the attachment
        /// </summary>
        /// <param name="field">Instance of <see cref="Field"/> </param>
        /// <returns>Instance of current <see cref="Attachment"/></returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="field"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when there are already 10 fields in the attachment</exception>
        public Attachment AddField([NotNull] Field field)
        {
            ArgumentNullException.ThrowIfNull(field, nameof(field));
            Fields ??= new List<Field>();
            if(Fields.Count >= 10)
            {
                throw new InvalidOperationException("Cannot add more than 10 fields to an attachment");
            }
            Fields.Add(field);
            return this;
        }
    }
}