namespace ChatAIze.Abstractions.Databases;

public interface IDatabaseFilter
{
    public string Property { get; }

    public FilterType Type { get; }

    public string Value { get; }

    public FilterOptions Options { get; }
}
