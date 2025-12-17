namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a setting that stores a string-to-string map (dictionary).
/// </summary>
/// <remarks>
/// In ChatAIze.Chatbot this is rendered as a repeatable key/value editor. Values are typically stored as a JSON object under
/// <see cref="ISetting.Id"/>.
/// </remarks>
public interface IMapSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, providing context or instructions for the user.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the placeholder text shown in the key input field.
    /// </summary>
    public string? KeyPlaceholder { get; }

    /// <summary>
    /// Gets the placeholder text shown in the value input field.
    /// </summary>
    public string? ValuePlaceholder { get; }

    /// <summary>
    /// Gets the maximum number of key-value pairs allowed in the map.
    /// </summary>
    public int MaxItems { get; }

    /// <summary>
    /// Gets the maximum number of characters allowed for each key.
    /// </summary>
    public int MaxKeyLength { get; }

    /// <summary>
    /// Gets the maximum number of characters allowed for each value.
    /// </summary>
    public int MaxValueLength { get; }

    /// <summary>
    /// Gets a flag indicating whether the control is disabled.
    /// </summary>
    public bool IsDisabled { get; }
}
