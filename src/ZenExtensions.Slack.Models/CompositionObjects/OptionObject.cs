using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    ///     An object that represents a single selectable item in a select menu, multi-select menu, checkbox group, radio button group, or overflow menu
    /// </summary>
    /// <param name="TextObject">
    ///     A <see cref="CompositionObjects.TextObject"/> that defines the text shown in the option on the menu. 
    ///     Overflow, select, and multi-select menus can only use plain_text objects, while radio buttons and checkboxes can use mrkdwn text objects. <br/> 
    ///     Maximum length for the text in this field is 75 characters.
    /// </param>
    /// <param name="Value">
    ///     A unique string value that will be passed to your app when this option is chosen. Maximum length for this field is 75 characters.
    /// </param>
    /// <param name="Description">
    ///     A <see cref="CompositionObjects.PlainTextObject"/> that defines a line of descriptive text shown below the text field beside the radio button. 
    ///     Maximum length for the text object within this field is 75 characters.
    /// </param>
    /// <param name="Url">
    ///     A URL to load in the user's browser when the option is clicked. 
    ///     The url attribute is only available in overflow menus. 
    ///     Maximum length for this field is 3000 characters. 
    ///     If you're using url, you'll still receive an interaction payload and will need to send an acknowledgement response.
    /// </param>
    public sealed record class OptionObject(
        [property: JsonPropertyName("text")]
        TextObject TextObject,
        [property: JsonPropertyName("value")]
        string Value,
        [property: JsonPropertyName("description")]
        PlainTextObject? Description = null,
        [property: JsonPropertyName("url")]
        string? Url = null
    ) : CompositionObject
    {
        internal override void Validate()
        {
            if (TextObject is null)
            {
                throw new InvalidOperationException("TextObject is required");
            }
            TextObject.Validate();
            if(TextObject.Text.Length > 75)
            {
                throw new InvalidOperationException("TextObject's text field should not be greater than 75 characters");
            }
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new InvalidOperationException("Value is required");
            }
            if (Value.Length > 75)
            {
                throw new InvalidOperationException("Value cannot be longer than 75 characters");
            }
            if(Description is not null)
            {
                Description.Validate();
                if(Description.Text.Length > 75)
                {
                    throw new InvalidOperationException("Description's text field should not be greater than 75 characters");
                }
            }
            if(Url is not null)
            {
                if(Url.Length > 3000)
                {
                    throw new InvalidOperationException("Url cannot be longer than 3000 characters");
                }
            }
        }
    }
}