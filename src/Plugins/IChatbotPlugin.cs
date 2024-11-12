using ChatAIze.Abstractions.Actions;
using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

public interface IChatbotPlugin
{
    public string Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public string? Website { get; }

    public string? Author { get; }

    public Version Version { get; }

    public DateTimeOffset? ReleaseTime { get; }

    public DateTimeOffset? LastUpdateTime { get; }

    public Func<IPluginSettings, CancellationToken, ValueTask<ICollection<IPluginSetting>>>? SettingsCallback { get; }

    public Func<IPluginSettings, CancellationToken, ValueTask<ICollection<IChatFunction>>>? FunctionsCallback { get; }

    public Func<IPluginSettings, CancellationToken, ValueTask<ICollection<IFunctionAction>>>? ActionsCallback { get; }
}
