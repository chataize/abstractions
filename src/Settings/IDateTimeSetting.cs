namespace ChatAIze.Abstractions.Settings;

public interface IDateSetting : IEditableSetting
{
    public DateTimeSettingStyle Style { get; }

    public DateTimeOffset DefaultValue { get; }

    public DateTimeOffset MinValue { get; }

    public DateTimeOffset MaxValue { get; }
}
