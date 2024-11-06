namespace ChatAIze.Abstractions.Settings;

public interface IMapSetting : IKeyedSetting
{
    public string KeyPlaceholder { get; }

    public string ValuePlaceholder { get; }

    public int MaxItems { get; }

    public int MaxKeyLength { get; }

    public int MaxValueLength { get; }
}
