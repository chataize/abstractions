namespace ChatAIze.Abstractions.Settings;

public interface ISettingSection : IPluginSetting
{
    public ICollection<IPluginSetting> Settings { get; }
}
