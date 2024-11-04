namespace ChatAIze.Abstractions.Settings;

public interface ISelectionSetting<T> : IEditableSetting
{
    public SelectionSettingStyle Style { get; }

    public ICollection<ISelectionChoice<T>> Choices { get; }

    public T DefaultValue { get; }
}
