namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Describes a tool/function that can be exposed to a language model.
/// </summary>
/// <remarks>
/// In the ChatAIze stack, <see cref="IChatFunction"/> is used by:
/// <list type="bullet">
/// <item><description><c>ChatAIze.GenerativeCS</c> to serialize a tool schema (name/description/parameters) for providers like OpenAI and Gemini.</description></item>
/// <item><description><c>ChatAIze.Chatbot</c> to aggregate built-in functions, dashboard-defined integrations, and plugin functions.</description></item>
/// </list>
/// <para>
/// For schema generation, at least one of <see cref="Parameters"/> or <see cref="Callback"/> must be provided.
/// If <see cref="Parameters"/> is <see langword="null"/>, hosts commonly infer parameters from <see cref="Callback"/> via reflection.
/// </para>
/// </remarks>
public interface IChatFunction
{
    /// <summary>
    /// Gets the function name.
    /// </summary>
    /// <remarks>
    /// Providers typically require names to be identifier-like. ChatAIze commonly normalizes names to snake_case when sending to providers.
    /// </remarks>
    public string Name { get; }

    /// <summary>
    /// Gets an optional description shown to the model and administrators.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag indicating whether the model must "double confirm" before the host executes the function.
    /// </summary>
    /// <remarks>
    /// ChatAIze.GenerativeCS implements this by requiring the model to call the tool twice: the first call returns a tool result
    /// asking for confirmation, and only the second call is actually executed.
    /// </remarks>
    public bool RequiresDoubleCheck { get; }

    /// <summary>
    /// Gets the delegate that executes the function.
    /// </summary>
    /// <remarks>
    /// Hosts may support an optional <see cref="IFunctionContext"/> parameter and/or a <see cref="CancellationToken"/> parameter.
    /// Return types are typically <see cref="string"/> or JSON-serializable objects (serialized and returned to the model).
    /// </remarks>
    public Delegate? Callback { get; }

    /// <summary>
    /// Gets an explicit parameter schema for the function.
    /// </summary>
    /// <remarks>
    /// When provided, this schema is used to generate provider tool definitions. When <see langword="null"/>, hosts commonly infer
    /// the schema from <see cref="Callback"/>.
    /// </remarks>
    public IReadOnlyCollection<IFunctionParameter>? Parameters { get; }
}
