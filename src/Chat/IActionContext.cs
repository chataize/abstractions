namespace ChatAIze.Abstractions.Chat;

public interface IActionContext : IConditionContext
{
    public void SetQuickReplies(params IReadOnlyCollection<IQuickReply> quickReplies);

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    public ValueTask SetUserPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
