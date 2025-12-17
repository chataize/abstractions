namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies which date/time controls should be shown for a date-time setting.
/// </summary>
public enum DateTimeSettingStyle
{
    /// <summary>
    /// Show both date and time pickers.
    /// </summary>
    DateTime,

    /// <summary>
    /// Show only a date picker.
    /// </summary>
    DateOnly,

    /// <summary>
    /// Show only a time picker.
    /// </summary>
    TimeOnly
}
