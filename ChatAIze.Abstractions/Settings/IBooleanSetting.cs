using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a boolean (true/false) toggle in a settings UI or dynamic form.
/// </summary>
/// <remarks>
/// Values are typically stored by the host as JSON (a boolean) under <see cref="ISetting.Id"/>.
/// </remarks>
public interface IBooleanSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
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
    /// Gets a flag indicating whether the UI should render the control in a compact layout.
    /// </summary>
    /// <remarks>
    /// Rendering is host-dependent. In ChatAIze.Chatbot this influences spacing/border rendering.
    /// </remarks>
    public bool IsCompact { get; }

    /// <summary>
    /// Gets a flag indicating whether the input is disabled.
    /// </summary>
    public bool IsDisabled { get; }
}
