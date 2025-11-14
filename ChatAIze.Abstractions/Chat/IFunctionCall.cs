namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a function call made by the chatbot, including the function name and its input arguments.
/// </summary>
public interface IFunctionCall
{
    /// <summary>
    /// Gets or sets the identifier of the tool or function call, if applicable.
    /// </summary>
    public string? ToolCallId { get; set; }

    /// <summary>
    /// Gets or sets the name of the function to invoke.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the arguments passed to the function, typically as a JSON string.
    /// </summary>
    public string Arguments { get; set; }
}
