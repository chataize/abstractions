using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a setting that allows the user to select one value from a predefined list of choices.
/// </summary>
public interface ISelectionSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title of the setting, shown in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, providing additional guidance or context.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the style used to display the selection options (e.g., dropdown, radio buttons).
    /// </summary>
    public SelectionSettingStyle Style { get; }

    /// <summary>
    /// Gets the default selected value for the setting.
    /// </summary>
    public string? DefaultValue { get; }

    /// <summary>
    /// Gets a flag indicating whether the setting should be displayed in a compact form (without a label).
    /// </summary>
    public bool IsCompact { get; }

    /// <summary>
    /// Gets a flag indicating whether the setting is disabled and not editable by the user.
    /// </summary>
    public bool IsDisabled { get; }

    /// <summary>
    /// Gets the collection of available choices for the setting.
    /// </summary>
    public IReadOnlyCollection<ISelectionChoice> Choices { get; }
}
