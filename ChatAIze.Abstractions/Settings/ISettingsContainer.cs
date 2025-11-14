namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a container that holds a collection of settings.
/// </summary>
public interface ISettingsContainer
{
    /// <summary>
    /// Gets the collection of settings contained in this container.
    /// </summary>
    public IReadOnlyCollection<ISetting> Settings { get; }
}
