namespace ChatAIze.Abstractions.Settings;

public interface IPluginSetting
{
    public string Key { get; }

    public string Title { get; }

    public string Description { get; }
}
