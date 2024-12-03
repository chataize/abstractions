namespace ChatAIze.Abstractions.Retrieval;

public interface IRetrievalItem
{
    public string Title { get; }

    public string? Description { get; }

    public string? Content { get; }

    public string? Folder { get; }

    public string? SourceUrl { get; }
}
