namespace ChatAIze.Abstractions.Settings;

public interface IListSetting : ISetting
{
    public string? Title { get; }

    public string? Description { get; }

    public string? ItemPlaceholder { get; }

    public int MaxItems { get; }

    public int MaxItemLength { get; }

    public bool IsDisabled { get; }
}
