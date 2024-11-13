using ChatAIze.Abstractions.Plugins;

namespace ChatAIze.Abstractions.Chat;

public interface IActionContext
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

    public ValueTask<T> GetUserPropertyAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);

    public ValueTask SetUserPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
