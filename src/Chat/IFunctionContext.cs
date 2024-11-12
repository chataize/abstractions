using ChatAIze.Abstractions.Plugins;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionContext
{
    public IPluginSettings Settings { get; }

    public Guid ChatId { get; }

    public Guid UserId { get; }

    public string? UserName { get; }

    public string? UserEmail { get; }

    public string? UserIpAddress { get; }

    public bool IsPreview { get; }

    public bool IsDebugModeOn { get; }

    public bool IsCommunicationSandboxed { get; }

    public T? GetPlugin<T>(string? id = null) where T : IChatbotPlugin;

    public ValueTask<string?> GetUserPropertyAsync(string key, CancellationToken cancellationToken = default);

    public ValueTask SetUserPropertyAsync(string key, string value, CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);
}
