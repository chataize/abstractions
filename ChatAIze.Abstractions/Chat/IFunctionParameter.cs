namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Describes a parameter in a tool/function schema.
/// </summary>
/// <remarks>
/// Parameter definitions are used to generate provider JSON schema (for example via <c>ChatAIze.GenerativeCS.Utilities.SchemaSerializer</c>).
/// Names and enum values are commonly normalized to snake_case when sent to providers.
/// </remarks>
public interface IFunctionParameter
{
    /// <summary>
    /// Gets the parameter name.
    /// </summary>
    /// <remarks>
    /// Providers generally expect identifier-like names. ChatAIze commonly normalizes names to snake_case.
    /// </remarks>
    public string Name { get; }

    /// <summary>
    /// Gets an optional description shown to the model.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the CLR type used to generate the JSON schema.
    /// </summary>
    /// <remarks>
    /// Prefer simple scalar types (<see cref="string"/>, <see cref="int"/>, <see cref="bool"/>, etc.) or simple POCOs with primitive properties.
    /// Complex graphs may not translate cleanly to provider schemas.
    /// </remarks>
    public Type Type { get; }

    /// <summary>
    /// Gets a flag indicating whether the parameter is required.
    /// </summary>
    public bool IsRequired { get; }

    /// <summary>
    /// Gets the allowed values (for enum-like parameters).
    /// </summary>
    /// <remarks>
    /// When non-empty, hosts typically emit a JSON schema <c>enum</c>. Values may be normalized to snake_case.
    /// </remarks>
    public IReadOnlyCollection<string> EnumValues { get; }
}
