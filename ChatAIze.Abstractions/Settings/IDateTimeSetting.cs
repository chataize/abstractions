using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a date/time picker field in a settings UI or dynamic form.
/// </summary>
/// <remarks>
/// Values are typically stored by the host as JSON (an ISO timestamp) under <see cref="ISetting.Id"/>.
/// </remarks>
public interface IDateTimeSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, providing context or instructions for the user.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the style used to display the date and/or time selection (e.g., date only, time only, or both).
    /// </summary>
    public DateTimeSettingStyle Style { get; }

    /// <summary>
    /// Gets the default date and/or time value for the setting.
    /// </summary>
    public DateTimeOffset DefaultValue { get; }

    /// <summary>
    /// Gets the minimum selectable date and/or time value.
    /// </summary>
    public DateTimeOffset MinValue { get; }

    /// <summary>
    /// Gets the maximum selectable date and/or time value.
    /// </summary>
    public DateTimeOffset MaxValue { get; }

    /// <summary>
    /// Gets a flag indicating whether the input is disabled.
    /// </summary>
    public bool IsDisabled { get; }
}
