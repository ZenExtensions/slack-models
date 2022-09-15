namespace ZenExtensions.Slack.Models.Http
{
    public static class TriggerRequestExtensions
    {
        public static Task SendResponse(this TriggerRequest request, Message message)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            ArgumentNullException.ThrowIfNull(request, nameof(request.ResponseUrl));
            ArgumentNullException.ThrowIfNull(message, nameof(message));
            return message.SendAsync(request.ResponseUrl!);
        }
    }
}