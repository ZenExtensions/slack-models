using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResponseType
    {
        [EnumMember(Value="ephemeral")]
        Ephemeral,
        [EnumMember(Value="in_channel")]
        InChannel
    }
}