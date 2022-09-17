using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    /// <summary>
    /// Constants for message response types
    /// </summary>
    public sealed class ResponseType
    {
        /// <summary>
        /// Represents that message will only be visible to the sender
        /// </summary>
        public const string EPHEMERAL = "ephemeral";
        /// <summary>
        /// Represents that message will only be visible for entire channel
        /// </summary>
        public const string IN_CHANNEL = "in_channel";
    }
}