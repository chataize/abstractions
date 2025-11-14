namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a single message in a chat conversation, which may include content, images, a function call, or a function result.
/// </summary>
/// <typeparam name="TFunctionCall">The type representing a function call within the message.</typeparam>
/// <typeparam name="TFunctionResult">The type representing the result of a function execution.</typeparam>
public interface IChatMessage<TFunctionCall, TFunctionResult>
    where TFunctionCall : IFunctionCall
    where TFunctionResult : IFunctionResult
{
    /// <summary>
    /// Gets or sets the role of the message sender (e.g., user, chatbot, system).
    /// </summary>
    public ChatRole Role { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who sent the message, if applicable.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the textual content of the message.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the collection of image URLs included with the message.
    /// </summary>
    public ICollection<string> ImageUrls { get; set; }

    /// <summary>
    /// Gets or sets the function calls associated with the message.
    /// </summary>
    public ICollection<TFunctionCall> FunctionCalls { get; set; }

    /// <summary>
    /// Gets or sets the result of a function execution associated with the message.
    /// </summary>
    public TFunctionResult? FunctionResult { get; set; }

    /// <summary>
    /// Gets or sets the pin location used to preserve the message when it exceeds the context length limit.
    /// This has no visual effect for the user.
    /// </summary>
    public PinLocation PinLocation { get; set; }
}
