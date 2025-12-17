using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a single-choice selection control (dropdown / radio / segmented).
/// </summary>
/// <remarks>
/// Values are typically stored by the host as JSON (a string) under <see cref="ISetting.Id"/>.
/// </remarks>
public interface ISelectionSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
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
    /// Gets a flag indicating whether the UI should render the control in a compact layout.
    /// </summary>
    /// <remarks>
    /// Rendering is host-dependent. In ChatAIze.Chatbot this influences spacing/border rendering.
    /// </remarks>
    public bool IsCompact { get; }

    /// <summary>
    /// Gets a flag indicating whether the control is disabled.
    /// </summary>
    public bool IsDisabled { get; }

    /// <summary>
    /// Gets the available choices.
    /// </summary>
    public IReadOnlyCollection<ISelectionChoice> Choices { get; }
}
