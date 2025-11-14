namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a configurable setting identified by a unique ID.
/// </summary>
public interface ISetting
{
    /// <summary>
    /// Gets the unique identifier of the setting.
    /// </summary>
    public string Id { get; }
}
