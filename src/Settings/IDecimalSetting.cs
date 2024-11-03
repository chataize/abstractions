namespace ChatAIze.Abstractions.Settings;

public interface IDecimalSetting : IPluginSetting
{
    public double DefaultValue { get; }

    public double MinValue { get; }

    public double MaxValue { get; }
}
