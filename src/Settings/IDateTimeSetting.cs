using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface IDateTimeSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public DateTimeSettingStyle Style { get; }

    public DateTimeOffset DefaultValue { get; }

    public DateTimeOffset MinValue { get; }

    public DateTimeOffset MaxValue { get; }
}
