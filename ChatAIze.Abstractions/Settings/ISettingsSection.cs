namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a top-level section in the settings interface that groups together related setting groups or individual settings.
/// </summary>
/// <remarks>
/// Visually, a <see cref="ISettingsSection"/> is displayed like a level-one heading (e.g., H1) in the user interface,
/// providing a high-level structure for organizing related groups or settings.
/// </remarks>
public interface ISettingsSection : ISetting, ISettingsContainer
{
    /// <summary>
    /// Gets the display title of the section, shown prominently as a heading in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the section, used to explain the purpose or context of the grouped settings.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag indicating whether all settings in the section are disabled and cannot be modified by the user.
    /// </summary>
    public bool IsDisabled { get; }
}
