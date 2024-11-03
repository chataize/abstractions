namespace ChatAIze.Abstractions.Settings;

public interface IDecimalSetting : IEditableSetting
{
    public double DefaultValue { get; }

    public double MinValue { get; }

    public double MaxValue { get; }
}
