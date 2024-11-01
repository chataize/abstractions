namespace ChatAIze.Abstractions.Chat;

public interface IChatFunction
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<IFunctionParameter> Parameters { get; set; }

    public bool RequiresDoubleCheck { get; set; }

    public Delegate? Callback { get; set; }
}
