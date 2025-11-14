namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents a structured database used within the chatbot system, including metadata and lifecycle tracking.
/// </summary>
public interface IDatabase
{
    /// <summary>
    /// Gets the unique identifier of the database.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the display title of the database.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets a normalized version of the database title, typically used for internal comparisons or indexing.
    /// </summary>
    public string NormalizedTitle { get; }

    /// <summary>
    /// Gets the optional description of the database.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag indicating whether the database has been marked as deleted.
    /// </summary>
    public bool IsDeleted { get; }

    /// <summary>
    /// Gets the timestamp when the database was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; }

    /// <summary>
    /// Gets the timestamp of the last update to the database.
    /// </summary>
    public DateTimeOffset LastUpdateTime { get; }

    /// <summary>
    /// Gets the timestamp when the database was deleted, if applicable.
    /// </summary>
    public DateTimeOffset? DeletionTime { get; }
}
