using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

public interface IChatbotPlugin
{
    public string Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public string? IconUrl { get; }

    public string? Website { get; }

    public string? Author { get; }

    public Version Version { get; }

    public DateTimeOffset? ReleaseTime { get; }

    public DateTimeOffset? LastUpdateTime { get; }

    public Func<IPluginSettings, CancellationToken, IReadOnlyCollection<ISetting>> SettingsCallback { get; }

    public Func<IPluginSettings, CancellationToken, IReadOnlyCollection<IChatFunction>> FunctionsCallback { get; }

    public Func<IPluginSettings, CancellationToken, IReadOnlyCollection<IFunctionAction>> ActionsCallback { get; }

    public Func<IPluginSettings, CancellationToken, IReadOnlyCollection<IFunctionCondition>> ConditionsCallback { get; }
}
