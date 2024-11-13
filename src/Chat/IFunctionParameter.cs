namespace ChatAIze.Abstractions.Chat;

public interface IFunctionParameter
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public Type Type { get; set; }

    public bool IsRequired { get; set; }

    public ICollection<string> EnumValues { get; set; }
}
