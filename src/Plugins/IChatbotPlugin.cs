using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

public interface IChatbotPlugin
{
    public Guid Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public string? Website { get; }

    public string? Author { get; }

    public string Version { get; }

    public DateTimeOffset? ReleaseTime { get; }

    public DateTimeOffset? LastUpdateTime { get; }

    public Func<IPluginSetting, CancellationToken, ValueTask<ICollection<IPluginSetting>>>? SettingsCallback { get; }

    public Func<IPluginSetting, CancellationToken, ValueTask<ICollection<IChatFunction>>>? FunctionsCallback { get; }
}
