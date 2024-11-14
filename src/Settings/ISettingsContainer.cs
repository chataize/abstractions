namespace ChatAIze.Abstractions.Settings;

public interface ISettingsContainer
{
    public IReadOnlyCollection<ISetting> Settings { get; }
}
