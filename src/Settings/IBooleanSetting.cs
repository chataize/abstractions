namespace ChatAIze.Abstractions.Settings;

public interface IBooleanSetting : IEditableSetting
{
    public BooleanSettingStyle Style { get; }

    public bool DefaultValue { get; }
}
