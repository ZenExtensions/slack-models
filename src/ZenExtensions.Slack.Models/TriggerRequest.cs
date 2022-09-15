using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models
{
    public sealed record class TriggerRequest
    (
        [property: JsonPropertyName("token")]
        string? Token = null,
        [property: JsonPropertyName("team_id")]
        string? TeamId = null,
        [property: JsonPropertyName("team_domain")]
        string? TeamDomain = null,
        [property: JsonPropertyName("channel_id")]
        string? ChannelId = null,
        [property: JsonPropertyName("channel_name")]
        string? ChannelName = null,
        [property: JsonPropertyName("user_id")]
        string? UserId = null,
        [property: JsonPropertyName("user_name")]
        string? Username = null,
        [property: JsonPropertyName("command")]
        string? Command = null,
        [property: JsonPropertyName("text")]
        string? Text = null,
        [property: JsonPropertyName("api_app_id")]
        string? ApiAppId = null,
        [property: JsonPropertyName("is_enterprise_install")]
        string? IsEnterpriseInstall = null,
        [property: JsonPropertyName("response_url")]
        string? ResponseUrl = null,
        [property: JsonPropertyName("trigger_id")]
        string? TriggerId = null
    );
}