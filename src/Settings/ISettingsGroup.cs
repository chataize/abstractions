namespace ChatAIze.Abstractions.Settings;

public interface ISettingsGroup : ISetting, ISettingsContainer
{
    public string? Title { get; }

    public string? Description { get; }

    public bool IsDisabled { get; }
}
