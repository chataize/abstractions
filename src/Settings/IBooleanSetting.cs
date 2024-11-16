using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface IBooleanSetting : ISetting, IDefaultValueObject
{
    public string? Title { get; }

    public string? Description { get; }

    public BooleanSettingStyle Style { get; }

    public bool DefaultValue { get; }

    public bool IsCompact { get; }

    public bool IsDisabled { get; }
}
