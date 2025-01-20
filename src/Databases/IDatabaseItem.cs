namespace ChatAIze.Abstractions.Databases;

public interface IDatabaseItem
{
    public Guid Id { get; }

    public Guid DatabaseId { get; }

    public IDatabase Database { get; }

    public string Title { get; }

    public string NormalizedTitle { get; }

    public string? Description { get; }

    public IReadOnlyDictionary<string, string?> Properties { get; }

    public bool IsDeleted { get; }

    public DateTimeOffset CreationTime { get; }

    public DateTimeOffset LastUpdateTime { get; }

    public DateTimeOffset? DeletionTime { get; }

    public string? GetPropertyValue(string title);
}
