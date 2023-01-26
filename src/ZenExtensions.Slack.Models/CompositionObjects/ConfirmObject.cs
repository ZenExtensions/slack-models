using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    ///     An object that defines a dialog that provides a confirmation step to any interactive element. This dialog will ask the user to confirm their action by offering a confirm and deny buttons.
    /// </summary>
    /// <param name="Title">
    ///     A <see cref="PlainTextObject"/> that defines the dialog's title. Maximum length for text in this field is 100 characters.
    /// </param>
    /// <param name="TextObject">
    ///     A <see cref="CompositionObjects.TextObject"/> that defines the explanatory text that appears in the confirm dialog. Maximum length for the text in this field is 300 characters.
    /// </param>
    /// <param name="Confirm">
    ///     A <see cref="PlainTextObject"/> define the text of the button that confirms the action. Maximum length for the text in this field is 30 characters.
    /// </param>
    /// <param name="Deny">
    ///     A <see cref="PlainTextObject"/> define the text of the button that cancels the action. Maximum length for the text in this field is 30 characters.
    /// </param>
    /// <param name="Style">
    ///     Defines the color scheme applied to the confirm button. <br/>
    ///     A value of danger will display the button with a red background on desktop, or red text on mobile. <br/>
    ///     A value of primary will display the button with a green background on desktop, or blue text on mobile. <br/>
    ///     If this field is not provided, the default value will be primary.
    /// </param>
    public sealed record class ConfirmObject(
        [property: JsonPropertyName("title"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        PlainTextObject Title,
        [property: JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        TextObject TextObject,
        [property: JsonPropertyName("confirm"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        PlainTextObject Confirm,
        [property: JsonPropertyName("deny"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        PlainTextObject Deny,
        [property: JsonPropertyName("style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string Style = "primary"
    ): CompositionObject
    {
        internal override void Validate()
        {
            if (Title is null)
            {
                throw new InvalidOperationException("Title is required");
            }
            Title.Validate();
            if(Title.Text.Length > 100)
            {
                throw new InvalidOperationException("Title text should not be greater than 100 characters");
            }

            if (TextObject is null)
            {
                throw new InvalidOperationException("TextObject is required");
            }
            TextObject.Validate();
            if(TextObject.Text.Length > 300)
            {
                throw new InvalidOperationException("TextObject's text field should not be greater than 300 characters");
            }
            if (Confirm is null)
            {
                throw new InvalidOperationException("Confirm is required");
            }
            Confirm.Validate();
            if(Confirm.Text.Length > 30)
            {
                throw new InvalidOperationException("Confirm text should not be greater than 30 characters");
            }

            if (Deny is null)
            {
                throw new InvalidOperationException("Deny is required");
            }
            Deny.Validate();
            if(Deny.Text.Length > 30)
            {
                throw new InvalidOperationException("Deny text should not be greater than 30 characters");
            }

            if(Style != null && !new [] { "primary", "danger"}.Contains(Style))
            {
                throw new InvalidOperationException("Style can be either of primary or danger.");
            }

        }
    }
}