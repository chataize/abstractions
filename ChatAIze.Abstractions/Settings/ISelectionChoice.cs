namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents an individual selectable option within a <see cref="ISelectionSetting"/>.
/// </summary>
public interface ISelectionChoice
{
    /// <summary>
    /// Gets the display title shown to the user.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the stored value associated with the choice.
    /// </summary>
    /// <remarks>
    /// This is the value persisted by the host and returned in settings dictionaries. Keep it stable across versions.
    /// </remarks>
    public string Value { get; }

    /// <summary>
    /// Gets a flag indicating whether this choice is disabled and cannot be selected.
    /// </summary>
    public bool IsDisabled { get; }
}
