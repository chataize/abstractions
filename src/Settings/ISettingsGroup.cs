namespace ChatAIze.Abstractions.Settings;

public interface ISettingGroup : IPluginSetting
{
    public ICollection<IPluginSetting> Settings { get; }
}
