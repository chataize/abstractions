namespace ChatAIze.Abstractions.Settings;

public interface ISettingsGroup : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public ICollection<IPluginSetting> Settings { get; }
}
