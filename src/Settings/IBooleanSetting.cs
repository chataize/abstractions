namespace ChatAIze.Abstractions.Settings;

public interface IBooleanSetting : IKeyedSetting
{
    public BooleanSettingStyle Style { get; }

    public bool DefaultValue { get; }
}
