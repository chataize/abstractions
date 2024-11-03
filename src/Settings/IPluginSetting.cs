namespace ChatAIze.Abstractions.Settings;

public interface IPluginSetting
{
    public string Title { get; }

    public string? Description { get; }
}
