using System.Text.Json.Serialization;

namespace ZenExtensions.Slack.Models
{
    /// <summary>
    /// Represents the body of message via slack slash request
    /// </summary>
    public sealed record class SlashRequestDto
    (
        [property: JsonPropertyName("token")]
        string[]? Token = null,
        [property: JsonPropertyName("team_id")]
        string[]? TeamId = null,
        [property: JsonPropertyName("team_domain")]
        string[]? TeamDomain = null,
        [property: JsonPropertyName("channel_id")]
        string[]? ChannelId = null,
        [property: JsonPropertyName("channel_name")]
        string[]? ChannelName = null,
        [property: JsonPropertyName("user_id")]
        string[]? UserId = null,
        [property: JsonPropertyName("user_name")]
        string[]? Username = null,
        [property: JsonPropertyName("command")]
        string[]? Command = null,
        [property: JsonPropertyName("text")]
        string[]? Text = null,
        [property: JsonPropertyName("api_app_id")]
        string[]? ApiAppId = null,
        [property: JsonPropertyName("is_enterprise_install")]
        string[]? IsEnterpriseInstall = null,
        [property: JsonPropertyName("response_url")]
        string[]? ResponseUrl = null,
        [property: JsonPropertyName("trigger_id")]
        string[]? TriggerId = null
    ) {
        /// <summary>
        /// Implicit conversion between dto and model
        /// </summary>
        /// <param name="dto">dto model</param>
        public static implicit operator SlashRequest(SlashRequestDto dto) => new SlashRequest(
            Token: dto.Token?[0],
            TeamId: dto.TeamId?[0],
            TeamDomain: dto.TeamDomain?[0],
            ChannelId: dto.ChannelId?[0],
            ChannelName: dto.ChannelName?[0],
            UserId: dto.UserId?[0],
            Username: dto.Username?[0],
            Command: dto.Command?[0],
            Text: dto.Text?[0],
            ApiAppId: dto.ApiAppId?[0],
            IsEnterpriseInstall: dto.IsEnterpriseInstall?[0],
            ResponseUrl: dto.ResponseUrl?[0],
            TriggerId: dto.TriggerId?[0]
        )
    }

    /// <summary>
    /// Represents the body of message via slack slash request
    /// </summary>
    public sealed record class SlashRequest
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