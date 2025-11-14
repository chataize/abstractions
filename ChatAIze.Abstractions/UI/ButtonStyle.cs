namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies the visual style to apply to a button in the user interface.
/// </summary>
public enum ButtonStyle
{
    /// <summary>
    /// The default button style.
    /// </summary>
    Default,

    /// <summary>
    /// A button with rounded corners for a softer visual appearance.
    /// </summary>
    Rounded,

    /// <summary>
    /// A minimal button with no border or background styling.
    /// </summary>
    Borderless,

    /// <summary>
    /// A lightly styled button, typically used for secondary or low-emphasis actions.
    /// </summary>
    Light,

    /// <summary>
    /// A primary button used for general main actions.
    /// </summary>
    Primary,

    /// <summary>
    /// A high-emphasis button used to highlight the most important or recommended action.
    /// </summary>
    Accent,

    /// <summary>
    /// A button that indicates a warning or potentially harmful action.
    /// </summary>
    Danger,

    /// <summary>
    /// A strong warning button style used for destructive or irreversible actions.
    /// </summary>
    Destructive
}
