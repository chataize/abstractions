namespace ChatAIze.Abstractions.Settings;

public interface IDecimalSetting : IKeyedSetting
{
    public double DefaultValue { get; }

    public double MinValue { get; }

    public double MaxValue { get; }
}
