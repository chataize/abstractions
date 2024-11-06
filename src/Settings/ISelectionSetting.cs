namespace ChatAIze.Abstractions.Settings;

public interface ISelectionSetting : IEditableSetting
{
    public SelectionSettingStyle Style { get; }

    public ICollection<ISelectionChoice> Choices { get; }

    public string DefaultValue { get; }
}
