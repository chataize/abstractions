namespace ChatAIze.Abstractions.Settings;

public interface ISettingsButton : IPluginSetting
{
    public ButtonStyle Style { get; }

    public Func<ValueTask> Callback { get; }
}
