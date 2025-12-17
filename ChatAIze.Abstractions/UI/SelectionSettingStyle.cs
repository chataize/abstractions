namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies how a single-choice selection setting should be rendered.
/// </summary>
public enum SelectionSettingStyle
{
    /// <summary>
    /// The host chooses the most appropriate style.
    /// </summary>
    /// <remarks>
    /// ChatAIze.Chatbot uses simple heuristics (for example: segmented control for a few choices, radio buttons for a small list,
    /// otherwise a drop-down).
    /// </remarks>
    Automatic,

    /// <summary>
    /// Displays options as a horizontal segmented control.
    /// Suitable for a small number of options.
    /// </summary>
    SegmentedControl,

    /// <summary>
    /// Displays options as a vertical list of radio buttons.
    /// </summary>
    RadioButtons,

    /// <summary>
    /// Displays options in a drop-down menu.
    /// </summary>
    DropDown
}
