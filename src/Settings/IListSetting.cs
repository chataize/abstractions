namespace ChatAIze.Abstractions.Settings;

public interface IListSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public string? ItemPlaceholder { get; }

    public int MaxItems { get; }

    public int MaxItemLength { get; }
}
