namespace ChatAIze.Abstractions.Settings;

public interface IMapSetting : IPluginSetting
{
    public string? Title { get; }

    public string? Description { get; }

    public string? KeyPlaceholder { get; }

    public string? ValuePlaceholder { get; }

    public int MaxItems { get; }

    public int MaxKeyLength { get; }

    public int MaxValueLength { get; }
}
