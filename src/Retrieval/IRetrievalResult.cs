namespace ChatAIze.Abstractions.Retrieval;

public interface IRetrievalResult
{
    public IReadOnlyList<IRetrievalItem> Items { get; }

    public IReadOnlyCollection<Guid> ChunkIds { get; }
}
