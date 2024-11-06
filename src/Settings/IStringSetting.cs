namespace ChatAIze.Abstractions.Settings;

public interface IStringSetting : IKeyedSetting
{
    public string? DefaultValue { get; }

    public string? Placeholder { get; }

    public int MaxLength { get; }

    public int EditorLines { get; }

    public bool IsSecret { get; }
}
