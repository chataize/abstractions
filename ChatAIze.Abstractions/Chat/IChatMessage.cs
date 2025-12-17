namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a single entry in a chat transcript.
/// </summary>
/// <remarks>
/// ChatAIze uses one message type to represent text turns, tool calls, and tool results:
/// <list type="bullet">
/// <item><description>Text messages usually have <see cref="Content"/> set and <see cref="FunctionCalls"/> empty.</description></item>
/// <item><description>Tool call messages are typically <see cref="ChatRole.Chatbot"/> with one or more <see cref="FunctionCalls"/>.</description></item>
/// <item><description>Tool result messages are typically <see cref="ChatRole.Function"/> with <see cref="FunctionResult"/> set.</description></item>
/// </list>
/// Hosts may also use <see cref="PinLocation"/> to influence which messages survive context trimming.
/// </remarks>
/// <typeparam name="TFunctionCall">The type representing a function call within the message.</typeparam>
/// <typeparam name="TFunctionResult">The type representing the result of a function execution.</typeparam>
public interface IChatMessage<TFunctionCall, TFunctionResult>
    where TFunctionCall : IFunctionCall
    where TFunctionResult : IFunctionResult
{
    /// <summary>
    /// Gets or sets the role associated with this message.
    /// </summary>
    public ChatRole Role { get; set; }

    /// <summary>
    /// Gets or sets an optional display name for the user (not a stable identifier).
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the text content.
    /// </summary>
    /// <remarks>
    /// For tool call/result messages this is often <see langword="null"/> and the structured fields are used instead.
    /// </remarks>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets image URLs attached to the message (provider support varies).
    /// </summary>
    public ICollection<string> ImageUrls { get; set; }

    /// <summary>
    /// Gets or sets tool/function calls requested by the model.
    /// </summary>
    /// <remarks>
    /// This is typically populated on <see cref="ChatRole.Chatbot"/> messages when the model chooses to call a tool.
    /// </remarks>
    public ICollection<TFunctionCall> FunctionCalls { get; set; }

    /// <summary>
    /// Gets or sets the tool/function result returned back to the model.
    /// </summary>
    public TFunctionResult? FunctionResult { get; set; }

    /// <summary>
    /// Gets or sets how this message should be treated during context trimming.
    /// </summary>
    /// <remarks>
    /// Pinning is used by hosts to build a provider prompt within a token budget and usually has no visual effect for the end user.
    /// </remarks>
    public PinLocation PinLocation { get; set; }
}
