namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a decimal (floating-point) setting that supports optional range limits and slider visualization in the UI.
/// </summary>
public interface IDecimalSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title of the setting, shown in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, used to provide guidance or context.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the default value for the setting.
    /// </summary>
    public double DefaultValue { get; }

    /// <summary>
    /// Gets the minimum allowable value for the setting.
    /// </summary>
    public double MinValue { get; }

    /// <summary>
    /// Gets the maximum allowable value for the setting.
    /// </summary>
    public double MaxValue { get; }

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
    /// Gets a flag indicating whether the setting is disabled and not editable by the user.
    /// </summary>
    public bool IsDisabled { get; }
}
