namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies how a selection-based setting should be displayed in the user interface.
/// </summary>
public enum SelectionSettingStyle
{
    /// <summary>
    /// The style is automatically chosen based on context or available space.
    /// </summary>
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
