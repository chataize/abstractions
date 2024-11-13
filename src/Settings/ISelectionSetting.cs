using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface ISelectionSetting : ISetting
{
    public string? Title { get; }

    public string? Description { get; }

    public SelectionSettingStyle Style { get; }

    public string? DefaultValue { get; }

    public bool IsCompact { get; }

    public bool IsDisabled { get; }

    public IReadOnlyCollection<ISelectionChoice>? Choices { get; }
}
