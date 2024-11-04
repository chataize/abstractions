using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

public interface IChatbotPlugin
{
    public Guid Id { get; }

    public string Name { get; }

    public string? Description { get; }

    public string Version { get; }

    public ICollection<IPluginSetting> Settings { get; }

    public ICollection<IChatFunction> Functions { get; }
}
