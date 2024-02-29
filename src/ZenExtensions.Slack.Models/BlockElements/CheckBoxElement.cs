using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenExtensions.Slack.Models.CompositionObjects;

namespace ZenExtensions.Slack.Models.BlockElements
{
    public sealed record class CheckBoxElement
    (
        List<OptionObject> Options,
        string? ActionId = null,
        List<OptionObject>? InitialOptions = null,
        ConfirmObject? Confirm = null,
        bool FocusOnLoad = false
    )
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; } = "checkboxes";
    }
}