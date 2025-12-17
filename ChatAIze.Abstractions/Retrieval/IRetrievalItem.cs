namespace ChatAIze.Abstractions.Retrieval;

/// <summary>
/// Represents a single piece of retrieved knowledge (a "hit") returned by semantic search.
/// </summary>
/// <remarks>
/// Retrieval items are used to provide grounding context to the language model and/or to show citations to users.
/// The <see cref="Content"/> may be a snippet rather than the full underlying document.
/// </remarks>
public interface IRetrievalItem
{
    /// <summary>
    /// Gets the display title of the item (for example: document title).
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets an optional short description or summary.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the content/snippet used as retrieval context.
    /// </summary>
    /// <remarks>
    /// This may be truncated. Hosts usually provide a separate API to fetch full document content by id/title.
    /// </remarks>
    public string? Content { get; }

    /// <summary>
    /// Gets the folder/category the item belongs to (if any).
    /// </summary>
    public string? Folder { get; }

    /// <summary>
    /// Gets an optional source URL for the item.
    /// </summary>
    /// <remarks>
    /// Hosts may surface this to users as a citation/link.
    /// </remarks>
    public string? SourceUrl { get; }
}
