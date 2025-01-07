namespace ChatAIze.Abstractions.Databases;

public interface IDatabaseSorting
{
    public string Property { get; }

    public SortOrder Order { get; }
}
