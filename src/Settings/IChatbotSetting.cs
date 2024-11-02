namespace ChatAIze.Abstractions.Settings;

public interface IChatbotSetting
{
    public string Key { get; }

    public string Title { get; }

    public string Description { get; }
}
