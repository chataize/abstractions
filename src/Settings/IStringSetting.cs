using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface IStringSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public string? Placeholder { get; }

    public string? DefaultValue { get; }

    public TextFieldType TextFieldType { get; }

    public int MaxLength { get; }

    public int EditorLines { get; }

    public bool IsDisabled { get; }
}
