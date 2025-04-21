namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a logical subgroup of settings within a section, typically used for organizing related options under a secondary heading.
/// </summary>
/// <remarks>
/// Visually, a <see cref="ISettingsGroup"/> is displayed like a level-two heading (e.g., H2), nested under a higher-level section heading.
/// </remarks>
public interface ISettingsGroup : ISetting, ISettingsContainer
{
    /// <summary>
    /// Gets the display title of the group, shown as a subheading in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the group, providing context or instructions for the grouped settings.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag indicating whether all settings in the group are disabled and not editable by the user.
    /// </summary>
    public bool IsDisabled { get; }
}
