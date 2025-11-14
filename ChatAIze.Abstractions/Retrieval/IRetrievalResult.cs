namespace ChatAIze.Abstractions.Retrieval;

/// <summary>
/// Represents the result of a knowledge retrieval operation, including matching items and their source identifiers.
/// </summary>
public interface IRetrievalResult
{
    /// <summary>
    /// Gets the list of retrieved items that matched the search query.
    /// </summary>
    public IReadOnlyList<IRetrievalItem> Items { get; }

    /// <summary>
    /// Gets the identifiers of the content chunks from which the retrieved items originated.
    /// </summary>
    public IReadOnlyCollection<Guid> ChunkIds { get; }
}
