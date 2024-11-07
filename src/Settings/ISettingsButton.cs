using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface ISettingsButton : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public ButtonStyle Style { get; }

    public Func<ValueTask> Callback { get; }
}
