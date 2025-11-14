namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a parameter accepted by a function within a chatbot context.
/// </summary>
public interface IFunctionParameter
{
    /// <summary>
    /// Gets the name of the parameter.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the optional description of the parameter, typically used to provide context or guidance to the user.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the data type of the parameter.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Gets a flag that indicates whether the parameter is required.
    /// </summary>
    public bool IsRequired { get; }

    /// <summary>
    /// Gets the list of allowed values if the parameter is an enumeration.
    /// </summary>
    public IReadOnlyCollection<string> EnumValues { get; }
}
