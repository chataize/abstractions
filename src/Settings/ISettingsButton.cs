namespace ChatAIze.Abstractions.Settings;

public interface ISettingsButton : IPluginSetting
{
    public Func<ValueTask> Callback { get; }
}
