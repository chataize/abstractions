using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface IListSetting : ISetting, IDefaultValueObject
{
    public string? Title { get; }

    public string? Description { get; }

    public string? ItemPlaceholder { get; }

    public TextFieldType TextFieldType { get; }

    public int MaxItems { get; }

    public int MaxItemLength { get; }

    public bool AllowDuplicates { get; }

    public bool IsLowercase { get; }

    public bool IsDisabled { get; }
}
