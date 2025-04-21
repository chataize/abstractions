namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the outcome of an executed action within a chatbot function.
/// </summary>
public interface IActionResult
{
    /// <summary>
    /// Gets the identifier of the action that produced this result.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the result value returned by the action.
    /// </summary>
    public object Result { get; }

    /// <summary>
    /// Gets a flag that indicates whether the action completed successfully.
    /// </summary>
    public bool IsSuccess { get; }
}
