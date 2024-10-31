namespace ChatAIze.Abstractions;

public interface IFunctionResult
{
    public string? ToolCallId { get; }

    public string Name { get; }

    public string Value { get; }
}
