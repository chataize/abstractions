namespace ChatAIze.Abstractions.Settings;

public interface ISettingsSection : IPluginSetting
{
    public ICollection<IPluginSetting> Settings { get; }
}
