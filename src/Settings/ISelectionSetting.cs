using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface ISelectionSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public SelectionSettingStyle Style { get; }

    public string DefaultValue { get; }

    public ICollection<ISelectionChoice> Choices { get; }
}
