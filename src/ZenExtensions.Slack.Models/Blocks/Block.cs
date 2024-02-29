using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.Blocks
{
    /// <summary>
    /// Block in slack
    /// </summary>
    public abstract record class Block(
        [property: JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string @Type
    )
    {

    }
}