using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenExtensions.Slack.Models.BlockElements;

namespace ZenExtensions.Slack.Models.Blocks
{
    public record class ContextBlock(
        [property: JsonPropertyName("elements"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        IEnumerable<BlockElement>? Elements
    ) : Block("context");
}