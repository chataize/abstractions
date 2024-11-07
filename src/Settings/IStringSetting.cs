namespace ChatAIze.Abstractions.Settings;

public interface IStringSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Caption { get; }

    public string? Placeholder { get; }

    public string? DefaultValue { get; }

    public int MaxLength { get; }

    public int EditorLines { get; }

    public bool IsSecure { get; }

    public bool IsDisabled { get; }
}
