namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents an individual item stored in a database, including custom properties, metadata, and lifecycle tracking.
/// </summary>
public interface IDatabaseItem
{
    /// <summary>
    /// Gets the unique identifier of the item.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the identifier of the database to which this item belongs.
    /// </summary>
    public Guid DatabaseId { get; }

    /// <summary>
    /// Gets the database that this item belongs to.
    /// </summary>
    public IDatabase Database { get; }

    /// <summary>
    /// Gets the display title of the item.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets a normalized version of the item's title, typically used for indexing or comparison.
    /// </summary>
    public string NormalizedTitle { get; }

    /// <summary>
    /// Gets the optional description of the item.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the dictionary of custom property values associated with this item.
    /// The key is the property name, and the value is the corresponding value.
    /// </summary>
    public IReadOnlyDictionary<string, string?> Properties { get; }

    /// <summary>
    /// Gets a flag indicating whether the item has been marked as deleted.
    /// </summary>
    public bool IsDeleted { get; }

    /// <summary>
    /// Gets the timestamp when the item was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; }

    /// <summary>
    /// Gets the timestamp of the last update to the item.
    /// </summary>
    public DateTimeOffset LastUpdateTime { get; }

    /// <summary>
    /// Gets the timestamp when the item was deleted, if applicable.
    /// </summary>
    public DateTimeOffset? DeletionTime { get; }

    /// <summary>
    /// Retrieves the value of a custom property by its title.
    /// </summary>
    /// <param name="title">The name of the property to retrieve.</param>
    /// <returns>The property value if found; otherwise, <c>null</c>.</returns>
    public string? GetPropertyValue(string title);
}
