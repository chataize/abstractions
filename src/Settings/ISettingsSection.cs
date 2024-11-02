namespace ChatAIze.Abstractions.Settings;

public interface ISettingSection
{
    public string Key { get; }

    public string Title { get; }

    public string Description { get; }
}
