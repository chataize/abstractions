using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface IIntegerSetting : IKeyedSetting
{
    public IntegerSettingStyle Style { get; }

    public int DefaultValue { get; }

    public int MinValue { get; }

    public int MaxValue { get; }

    public int Step { get; }

    public bool ShowSliderValue { get; }

    public bool ShowSliderPercentage { get; }
}
