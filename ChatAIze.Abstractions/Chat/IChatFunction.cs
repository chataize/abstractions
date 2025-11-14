namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a callable function available to the chatbot, including its name, parameters, and execution logic.
/// </summary>
public interface IChatFunction
{
    /// <summary>
    /// Gets the name of the function.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the optional description of the function.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag that indicates whether the chatbot must verbally confirm the user's intent twice before executing the function.
    /// </summary>
    /// <remarks>
    /// This confirmation is performed via chat messages, not through a popup or visual dialog.
    /// </remarks>
    public bool RequiresDoubleCheck { get; }

    /// <summary>
    /// Gets the delegate that defines the function's execution logic.
    /// </summary>
    public Delegate? Callback { get; }

    /// <summary>
    /// Gets the collection of parameters expected by the function.
    /// </summary>
    public IReadOnlyCollection<IFunctionParameter>? Parameters { get; }
}
