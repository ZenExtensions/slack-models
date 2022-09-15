using System.Net.Http.Json;

namespace ZenExtensions.Slack.Models.Http
{
    public static class MessageExtensions
    {
        private static readonly HttpClient _client = new Lazy<HttpClient>(() => new ()).Value;
        public static async Task SendAsync(this Message message, string responseUrl)
        {
            ArgumentNullException.ThrowIfNull(message, nameof(message));
            ArgumentNullException.ThrowIfNull(responseUrl, nameof(responseUrl));
            var response = await _client.PostAsJsonAsync(responseUrl, message);
            response.EnsureSuccessStatusCode();
        }
    }
}