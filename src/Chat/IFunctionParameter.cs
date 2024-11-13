namespace ChatAIze.Abstractions.Chat;

public interface IFunctionParameter
{
    public string Name { get; }

    public string? Description { get; }

    public Type Type { get; }

    public bool IsRequired { get; }

    public IReadOnlyCollection<string> EnumValues { get; }
}
