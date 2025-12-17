namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the recorded outcome of a single <see cref="IFunctionAction"/> execution.
/// </summary>
/// <remarks>
/// In ChatAIze.Chatbot, a function run typically returns either:
/// <list type="bullet">
/// <item><description>a list of <see cref="IActionResult"/> entries (one per executed action), or</description></item>
/// <item><description>an explicit function result set via <see cref="IActionContext.SetFunctionResult"/>.</description></item>
/// </list>
/// </remarks>
public interface IActionResult
{
    /// <summary>
    /// Gets the identifier of the action that produced this result.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the result payload produced by the action.
    /// </summary>
    /// <remarks>
    /// This is often a <see cref="string"/> or a JSON-serializable object.
    /// </remarks>
    public object Result { get; }

    /// <summary>
    /// Gets a flag indicating whether the action completed successfully.
    /// </summary>
    public bool IsSuccess { get; }
}
