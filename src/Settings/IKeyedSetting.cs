namespace ChatAIze.Abstractions.Settings;

public interface IKeyedSetting : IPluginSetting
{
    public string Key { get; }
}
