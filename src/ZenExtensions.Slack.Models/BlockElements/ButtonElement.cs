using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenExtensions.Slack.Models.CompositionObjects;

namespace ZenExtensions.Slack.Models.BlockElements
{
    public sealed record class ButtonElement(
        PlainTextObject Text,
        string ActionId,
        string Url,
        string Value,
        string Style,
        ConfirmObject Confirm,
        string AccessibilityLabel
    ) : BlockElement
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; } = "button";
    }
}