namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents a single record/item inside a custom database.
/// </summary>
/// <remarks>
/// Items have a display <see cref="Title"/> and an open-ended set of string properties (<see cref="Properties"/>).
/// Hosts often normalize titles and property keys to make lookups tolerant of casing and punctuation.
/// </remarks>
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
    /// Gets a normalized version of <see cref="Title"/> used for indexing or comparison.
    /// </summary>
    public string NormalizedTitle { get; }

    /// <summary>
    /// Gets the optional description of the item.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the dictionary of custom property values for this item.
    /// </summary>
    /// <remarks>
    /// In ChatAIze.Chatbot the keys are typically normalized property identifiers (snake_case), not the original display titles.
    /// Use <see cref="GetPropertyValue"/> when you want the host to normalize the lookup key for you.
    /// </remarks>
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
    /// Retrieves a property value by name/title.
    /// </summary>
    /// <param name="title">The name of the property to retrieve.</param>
    /// <returns>The property value if found; otherwise, <c>null</c>.</returns>
    /// <remarks>
    /// Hosts commonly normalize <paramref name="title"/> for comparison (for example snake_case, case-insensitive).
    /// </remarks>
    public string? GetPropertyValue(string title);
}
