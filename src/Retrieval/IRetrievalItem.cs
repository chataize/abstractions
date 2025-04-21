namespace ChatAIze.Abstractions.Retrieval;

/// <summary>
/// Represents an item retrieved from a knowledge base or document source.
/// </summary>
public interface IRetrievalItem
{
    /// <summary>
    /// Gets the title of the retrieved item.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the optional description of the item, typically used to summarize its content.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the full content of the item, if available.
    /// </summary>
    public string? Content { get; }

    /// <summary>
    /// Gets the folder or category the item belongs to, if applicable.
    /// </summary>
    public string? Folder { get; }

    /// <summary>
    /// Gets the source URL of the item, if it originated from an external system or document.
    /// </summary>
    public string? SourceUrl { get; }
}
