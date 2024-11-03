namespace ChatAIze.Abstractions.Settings;

public interface IBooleanSetting : IPluginSetting
{
    public BooleanSettingStyle Style { get; }

    public bool DefaultValue { get; }
}
