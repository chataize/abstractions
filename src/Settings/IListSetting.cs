namespace ChatAIze.Abstractions.Settings;

public interface IListSetting : IEditableSetting
{
    public int MaxItems { get; }

    public int MaxItemLength { get; }
}
