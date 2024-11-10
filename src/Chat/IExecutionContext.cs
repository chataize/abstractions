using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IExecutionContext
{
    public IPluginSettings Settings { get; }

    public Guid ChatId { get; }

    public Guid UserId { get; }

    public string? UserName { get; }

    public string? UserEmail { get; }

    public ValueTask<string?> GetUserPropertyAsync(string key, CancellationToken cancellationToken = default);

    public ValueTask SetUserPropertyAsync(string key, string value, CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    public ValueTask<object?> InvokeSharedMethodAsync(string name, CancellationToken cancellationToken = default, params object?[] args);
}
