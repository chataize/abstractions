namespace ChatAIze.Abstractions.Settings;

public interface ISettingsGroup : IPluginSetting
{
    public ICollection<IPluginSetting> Settings { get; }
}
