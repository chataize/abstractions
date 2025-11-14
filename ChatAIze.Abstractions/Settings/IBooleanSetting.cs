using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a boolean (true/false) setting that can be displayed and configured in the user interface.
/// </summary>
public interface IBooleanSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title of the setting, shown in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, providing additional context or guidance to the user.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the visual style used to present the setting (e.g., toggle switch or checkbox).
    /// </summary>
    public BooleanSettingStyle Style { get; }

    /// <summary>
    /// Gets the default value of the setting.
    /// </summary>
    public bool DefaultValue { get; }

    /// <summary>
    /// Gets a flag indicating whether the setting should be displayed in a compact form (without a label).
    /// </summary>
    public bool IsCompact { get; }

    /// <summary>
    /// Gets a flag indicating whether the setting is disabled and not editable by the user.
    /// </summary>
    public bool IsDisabled { get; }
}
