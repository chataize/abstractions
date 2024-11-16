using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionContext : IConditionContext
{
    public void SetStatus(string? status, double? progress = null);

    public void SetQuickReplies(params IReadOnlyCollection<IQuickReply>? quickReplies);

    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    public ValueTask<(bool, IDictionary<string, object>)> ShowFormAsync(string title, string confirmText = "Confirm", string cancelText = "Cancel", CancellationToken cancellationToken = default, params IReadOnlyCollection<ISetting> settings);

    public ValueTask SetUserPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
