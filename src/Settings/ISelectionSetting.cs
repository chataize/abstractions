namespace ChatAIze.Abstractions.Settings;

public interface ISelectionSetting : IKeyedSetting
{
    public SelectionSettingStyle Style { get; }

    public ICollection<ISelectionChoice> Choices { get; }

    public string DefaultValue { get; }
}
