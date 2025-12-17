using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents an integer input field (stepper or slider) in a settings UI or dynamic form.
/// </summary>
/// <remarks>
/// Values are typically stored by the host as JSON (a number) under <see cref="ISetting.Id"/>.
/// </remarks>
public interface IIntegerSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, providing additional context or usage information.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the style used to display the setting in the user interface (e.g., stepper or slider).
    /// </summary>
    public IntegerSettingStyle Style { get; }

    /// <summary>
    /// Gets the default integer value of the setting.
    /// </summary>
    public int DefaultValue { get; }

    /// <summary>
    /// Gets the minimum allowable value for the setting.
    /// </summary>
    public int MinValue { get; }

    /// <summary>
    /// Gets the maximum allowable value for the setting.
    /// </summary>
    public int MaxValue { get; }

    /// <summary>
    /// Gets the increment/decrement step used by the UI.
    /// </summary>
    /// <remarks>
    /// Hosts may clamp or replace invalid values (for example a non-positive step).
    /// </remarks>
    public int Step { get; }

    /// <summary>
    /// Gets a flag indicating whether the current slider value should be displayed.
    /// </summary>
    public bool ShowSliderValue { get; }

    /// <summary>
    /// Gets a flag indicating whether the slider value should be shown as a percentage relative to the range.
    /// </summary>
    public bool ShowSliderPercentage { get; }

    /// <summary>
    /// Gets the label to display when the slider is at the minimum value.
    /// </summary>
    /// <remarks>
    /// If set, this replaces the default value indicator when the slider is at the minimum.
    /// If <c>null</c>, the default numeric value is shown instead.
    /// </remarks>
    public string? MinValueLabel { get; }

    /// <summary>
    /// Gets the label to display when the slider is at the maximum value.
    /// </summary>
    /// <remarks>
    /// If set, this replaces the default value indicator when the slider is at the maximum.
    /// If <c>null</c>, the default numeric value is shown instead.
    /// </remarks>
    public string? MaxValueLabel { get; }

    /// <summary>
    /// Gets a flag indicating whether the input is disabled.
    /// </summary>
    public bool IsDisabled { get; }
}
