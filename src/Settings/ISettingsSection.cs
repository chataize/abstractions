namespace ChatAIze.Abstractions.Settings;

public interface ISettingsSection : ISetting
{
    public string? Title { get; }

    public string? Description { get; }

    public bool IsDisabled { get; }

    public IReadOnlyCollection<ISetting> Settings { get; }
}
