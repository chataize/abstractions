namespace ChatAIze.Abstractions.Settings;

public interface ISettingsSection : ISetting, ISettingsContainer
{
    public string? Title { get; }

    public string? Description { get; }

    public bool IsDisabled { get; }
}
