namespace ChatAIze.Abstractions.Actions.Properties;

public interface IDecimalProperty : IActionProperty
{
    public string? Title { get; }

    public string? Description { get; }

    public double DefaultValue { get; }

    public double MinValue { get; }

    public double MaxValue { get; }

    public bool ShowSliderValue { get; }

    public bool ShowSliderPercentage { get; }

    public string? MinValueLabel { get; }

    public string? MaxValueLabel { get; }

    public bool IsDisabled { get; }
}
