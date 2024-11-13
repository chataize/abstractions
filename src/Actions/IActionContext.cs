using ChatAIze.Abstractions.Plugins;

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

    public T? GetPlugin<T>(string? id = null) where T : IChatbotPlugin;

    public ValueTask<string?> GetUserPropertyAsync(string id, CancellationToken cancellationToken = default);

    public ValueTask SetUserPropertyAsync(string id, string value, CancellationToken cancellationToken = default);
}
