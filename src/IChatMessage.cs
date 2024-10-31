namespace ChatAIze.Abstractions;

public interface IChatMessage
{
    public ChatRole Role { get; }

    public string? Content { get; }

    public ICollection<IFunctionCall> FunctionCalls { get; }

    public IFunctionResult? Result { get; }

    public DateTimeOffset CreationTime { get; }
}
