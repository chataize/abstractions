namespace ChatAIze.Abstractions.Retrieval;

/// <summary>
/// Represents the result of a retrieval operation (semantic search).
/// </summary>
/// <remarks>
/// Hosts typically return both:
/// <list type="bullet">
/// <item><description><see cref="Items"/>: the human-/model-readable matches,</description></item>
/// <item><description><see cref="ChunkIds"/>: internal identifiers for the content chunks used to build the result.</description></item>
/// </list>
/// Chunk ids can be fed back into subsequent searches to avoid repeating the same sources.
/// </remarks>
public interface IRetrievalResult
{
    /// <summary>
    /// Gets the list of retrieved items that matched the search query.
    /// </summary>
    public IReadOnlyList<IRetrievalItem> Items { get; }

    /// <summary>
    /// Gets identifiers of content chunks that contributed to this result.
    /// </summary>
    public IReadOnlyCollection<Guid> ChunkIds { get; }
}
