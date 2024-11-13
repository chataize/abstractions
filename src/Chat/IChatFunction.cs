namespace ChatAIze.Abstractions.Chat;

public interface IChatFunction
{
    public string Name { get; }

    public string? Description { get; }

    public bool RequiresDoubleCheck { get; }

    public Delegate? Callback { get; }

    public IReadOnlyCollection<IFunctionParameter>? Parameters { get; }
}
