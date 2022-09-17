namespace ZenExtensions.Slack.Models.Http
{
    /// <summary>
    /// Http extensions for <see cref="SlashRequest"/>
    /// </summary>
    public static class SlashRequestExtensions
    {
        /// <summary>
        /// Send response to the slack request with a <see cref="Message"/>
        /// </summary>
        /// <param name="request">Instance of <see cref="SlashRequest"/></param>
        /// <param name="message">Message you want to send </param>
        /// <returns><see cref="Task"/> indicating completion of sent process</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> or <paramref name="message"/> is null</exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        public static Task SendResponse(this SlashRequest request, Message message)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            ArgumentNullException.ThrowIfNull(request, nameof(request.ResponseUrl));
            ArgumentNullException.ThrowIfNull(message, nameof(message));
            return message.SendAsync(request.ResponseUrl!);
        }
    }
}