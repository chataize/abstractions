using ChatAIze.Abstractions.Plugins;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Actions;

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

    public T? GetPlugin<T>(Guid? id = null) where T : IChatbotPlugin;

    public ValueTask<string?> GetUserPropertyAsync(string key, CancellationToken cancellationToken = default);

    public ValueTask SetUserPropertyAsync(string key, string value, CancellationToken cancellationToken = default);
}
