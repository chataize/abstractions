namespace ChatAIze.Abstractions.Settings;

public interface IDecimalSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public double DefaultValue { get; }

    public double MinValue { get; }

    public double MaxValue { get; }

    public bool IsDisabled { get; }
}
