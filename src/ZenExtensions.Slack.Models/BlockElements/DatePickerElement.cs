using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenExtensions.Slack.Models.CompositionObjects;

namespace ZenExtensions.Slack.Models.BlockElements
{
    public sealed record class DatePickerElement
    (
        string? ActionId = null,
        DateOnly? InitialDate = null,
        ConfirmObject? Confirm = null,
        bool FocusOnLoad = false,
        PlainTextObject? Placeholder = null
    )
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; } = "datepicker";
    }
}