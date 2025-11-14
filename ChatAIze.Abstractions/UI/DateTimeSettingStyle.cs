namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies how a date and/or time setting should be displayed in the user interface.
/// </summary>
public enum DateTimeSettingStyle
{
    /// <summary>
    /// Displays both the date and time selection controls.
    /// </summary>
    DateTime,

    /// <summary>
    /// Displays only the date selection control.
    /// </summary>
    DateOnly,

    /// <summary>
    /// Displays only the time selection control.
    /// </summary>
    TimeOnly
}
