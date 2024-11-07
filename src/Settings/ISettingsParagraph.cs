namespace ChatAIze.Abstractions.Settings;

public interface ISettingsParagraph : IPluginSetting
{
    public string? Content { get; }
}
