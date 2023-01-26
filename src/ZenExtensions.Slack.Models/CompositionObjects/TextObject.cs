using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    /// An object containing some text
    /// </summary>
    /// <param name="Text">
    ///     The text for the block. This field accepts any of the standard text formatting markup when type is mrkdwn. Maximum length for the text in this field is 3000 characters.
    /// </param>
    public abstract record class TextObject(
        [property: JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string Text
    ) : CompositionObject
    {
        /// <summary>
        ///    The formatting to use for this text object. Can be one of plain_textor mrkdwn.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public abstract string Type { get; protected internal set; }
    }
}