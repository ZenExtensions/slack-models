using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    /// An object containing some plain text
    /// </summary>
    /// <param name="Text">
    ///     <inheritdoc cref="TextObject.Text" path="/summary"/>
    /// </param>
    /// <param name="Emoji">
    ///     Indicates whether emojis in a text field should be escaped into the colon emoji format
    /// </param>
    public sealed record class PlainTextObject(
        string Text,
        [property: JsonPropertyName("emoji"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        bool? Emoji = null
    ) : TextObject(Text)
    {
        /// <inheritdoc/>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string Type { get; protected internal set; } = "plain_text";
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                throw new ArgumentException("Text is required");
            }
            if (Text.Length > 3000)
            {
                throw new ArgumentException("Text cannot be longer than 3000 characters");
            }
        }
        /// <summary>
        /// Creates a new instance of <see cref="PlainTextObject"/> from text
        /// </summary>
        /// <param name="text">text value for plain text object</param>
        public static implicit operator PlainTextObject(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }
            return new(text);
        }
    }
}