using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenExtensions.Slack.Models.CompositionObjects;

namespace ZenExtensions.Slack.Models.BlockElements
{
    public sealed record class DateTimePickerElement
    (
        string? ActionId = null,
        DateTime? InitialDateTime = null,
        ConfirmObject? Confirm = null,
        bool FocusOnLoad = false
    )
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; } = "datetimepicker";
    }
}