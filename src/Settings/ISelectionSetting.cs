namespace ChatAIze.Abstractions.Settings;

public interface ISelectionSetting : IPluginSetting
{
    public SelectionSettingStyle Style { get; }

    public ICollection<ISelectionChoice> Choices { get; }
}
