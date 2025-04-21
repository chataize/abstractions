namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies how an integer setting should be displayed in the user interface.
/// </summary>
public enum IntegerSettingStyle
{
    /// <summary>
    /// Displays the setting as a stepper control, allowing the user to increment or decrement the value.
    /// </summary>
    Stepper,

    /// <summary>
    /// Displays the setting as a slider, allowing the user to select a value within a defined range.
    /// </summary>
    Slider
}
