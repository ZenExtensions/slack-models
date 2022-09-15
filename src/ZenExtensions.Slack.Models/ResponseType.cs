using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    public sealed class ResponseType
    {
        public const string EPHEMERAL = "ephemeral";
        public const string IN_CHANNEL = "in_channel";
    }
}