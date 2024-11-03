namespace ChatAIze.Abstractions.Settings;

public interface IIntegerSetting : IPluginSetting
{
    public IntegerSettingStyle Style { get; }

    public int DefaultValue { get; }

    public int MinValue { get; }

    public int MaxValue { get; }
}
