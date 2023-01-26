using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    /// An object containing some markdown text
    /// </summary>
    /// <param name="Text">
    ///     <inheritdoc cref="TextObject.Text" path="/summary"/>
    /// </param>
    /// <param name="Verbatim">
    ///     When set to false (as is default) URLs will be auto-converted into links, conversation names will be link-ified, and certain mentions will be automatically parsed. <br/>
    ///     Using a value of true will skip any preprocessing of this nature, although you can still include manual parsing strings.
    /// </param>
    public sealed record class MarkdownTextObject(
        string Text,
        [property: JsonPropertyName("verbatim"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        bool? Verbatim = null
    ) : TextObject(Text)
    {
        /// <inheritdoc/>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public override string Type { get; protected internal set; } = "mrkdwn";
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                throw new InvalidOperationException("Text is required");
            }
            if (Text.Length > 3000)
            {
                throw new InvalidOperationException("Text cannot be longer than 3000 characters");
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="MarkdownTextObject"/> from text
        /// </summary>
        /// <param name="text">text value for markdown text object</param>
        public static implicit operator MarkdownTextObject(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }
            return new (text);
        }
    }
}