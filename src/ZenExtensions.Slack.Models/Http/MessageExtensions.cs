using System.Net.Http.Json;

namespace ZenExtensions.Slack.Models.Http
{
    /// <summary>
    /// Http extensions for <see cref="Message"/>
    /// </summary>
    public static class MessageExtensions
    {
        private static readonly HttpClient _client = new Lazy<HttpClient>(() => new ()).Value;
        /// <summary>
        /// Sends a <see cref="Message"/> to the endpoint specified
        /// </summary>
        /// <param name="message">Message you want to send </param>
        /// <param name="responseUrl">Url you want to send message to</param>
        /// <returns><see cref="Task"/> indicating completion of sent process</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> or <paramref name="responseUrl"/> is null</exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        public static async Task SendAsync(this Message message, string responseUrl)
        {
            ArgumentNullException.ThrowIfNull(message, nameof(message));
            ArgumentNullException.ThrowIfNull(responseUrl, nameof(responseUrl));
            var response = await _client.PostAsJsonAsync(responseUrl, message);
            response.EnsureSuccessStatusCode();
        }
    }
}