namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the result of a function execution within a chat context.
/// </summary>
public interface IFunctionResult
{
    /// <summary>
    /// Gets or sets the identifier of the tool or function call that produced this result, if applicable.
    /// </summary>
    public string? ToolCallId { get; set; }

    /// <summary>
    /// Gets or sets the name of the function that returned the result.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the result value returned by the function.
    /// </summary>
    public string Value { get; set; }
}
