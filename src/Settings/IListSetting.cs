namespace ChatAIze.Abstractions.Settings;

public interface IListSetting : IEditableSetting
{
    public string ItemPlaceholder { get; }

    public int MaxItems { get; }

    public int MaxItemLength { get; }
}
