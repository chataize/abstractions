namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies the visual emphasis of a button in the UI.
/// </summary>
public enum ButtonStyle
{
    /// <summary>
    /// Default button style.
    /// </summary>
    Default,

    /// <summary>
    /// Rounded button variant.
    /// </summary>
    Rounded,

    /// <summary>
    /// Minimal button with no border/background styling.
    /// </summary>
    Borderless,

    /// <summary>
    /// Low-emphasis button.
    /// </summary>
    Light,

    /// <summary>
    /// Primary call-to-action button.
    /// </summary>
    Primary,

    /// <summary>
    /// High-emphasis accent button.
    /// </summary>
    Accent,

    /// <summary>
    /// Warning/danger button for potentially harmful actions.
    /// </summary>
    Danger,

    /// <summary>
    /// Strong warning button for destructive or irreversible actions.
    /// </summary>
    Destructive
}
