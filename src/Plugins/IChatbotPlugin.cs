using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

public interface IChatbotPlugin
{
    public Guid Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public string Version { get; }

    public Func<ValueTask<ICollection<IPluginSetting>>> SettingsCallback { get; }

    public Func<ValueTask<ICollection<IChatFunction>>> FunctionsCallback { get; }
}
