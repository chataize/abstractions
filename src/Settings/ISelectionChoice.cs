namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents an individual selectable option within a <see cref="ISelectionSetting"/>.
/// </summary>
public interface ISelectionChoice
{
    /// <summary>
    /// Gets the display title of the choice, shown in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the value associated with the choice.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Gets a flag indicating whether this choice is disabled and cannot be selected.
    /// </summary>
    public bool IsDisabled { get; }
}
