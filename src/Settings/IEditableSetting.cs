namespace ChatAIze.Abstractions.Settings;

public interface IEditableSetting : IPluginSetting
{
    public string Key { get; }
}
