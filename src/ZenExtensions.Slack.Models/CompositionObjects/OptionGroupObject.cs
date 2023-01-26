using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    /// Provides a way to group options in a select menu or multi-select menu.
    /// </summary>
    /// <param name="Label">
    ///     A <see cref="PlainTextObject"/> that defines the label shown above this group of options. Maximum length for the text in this field is 75 characters.    
    /// </param>
    public sealed record class OptionGroupObject(
        [property: JsonPropertyName("label"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        PlainTextObject Label
    ) : CompositionObject
    {

        /// <summary>
        ///     An list of <see cref="OptionObject"/> that belong to this specific group. Maximum of 100 items.
        /// </summary>
        [JsonPropertyName("options"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<OptionObject>? Options { get; private set; }

        /// <summary>
        /// Adds a new option to the group
        /// </summary>
        /// <param name="option">Instance of <see cref="OptionObject"/></param>
        /// <returns>Instance of current <see cref="OptionGroupObject"/></returns>
        public OptionGroupObject AddOption([NotNull] OptionObject option)
        {
            ArgumentNullException.ThrowIfNull(option, nameof(option));
            option.Validate();
            Options ??= new List<OptionObject>();
            if(Options.Count >= 100)
            {
                throw new InvalidOperationException("Cannot add more than 100 options to an option group");
            }
            Options.Add(option);
            return this;
        }

        internal override void Validate()
        {
            if (Label is null)
            {
                throw new InvalidOperationException("Label is required");
            }
            Label.Validate();
            if (Label.Text.Length > 75)
            {
                throw new InvalidOperationException("Label's text field should not be greater than 75 characters");
            }
            if (Options is null)
            {
                throw new InvalidOperationException("Options is required");
            }
            if (Options.Count > 100)
            {
                throw new InvalidOperationException("Options cannot be longer than 100 items");
            }
        }
    }
}