namespace ChatAIze.Abstractions.Settings;

public interface IStringSetting : IPluginSetting
{
    public string? Value { get; }

    public string? DefaultValue { get; }

    public string? Placeholder { get; }

    public int MaxLength { get; }

    public int EditorLines { get; }

    public bool IsSecret { get; }
}
