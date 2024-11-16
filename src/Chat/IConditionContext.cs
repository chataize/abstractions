using ChatAIze.Abstractions.Plugins;

namespace ChatAIze.Abstractions.Chat;

public interface IConditionContext
{
    public IPluginSettings Settings { get; }

    public Guid ChatId { get; }

    public IUserContext User { get; }

    public bool IsPreview { get; }

    public bool IsDebugModeOn { get; }

    public bool IsCommunicationSandboxed { get; }

    public T? GetPlugin<T>(string? id = null) where T : IChatbotPlugin;

    public ValueTask<T> GetUserPropertyAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);
}
