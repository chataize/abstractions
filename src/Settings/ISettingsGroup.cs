namespace ChatAIze.Abstractions.Settings;

public interface ISettingGroup
{
    public string Key { get; }

    public string Title { get; }

    public string Description { get; }
}
