namespace ChatAIze.Abstractions;

public interface IFunctionCall
{
    public string? ToolCallId { get; }

    public string Name { get; }

    public string Arguments { get; }
}
