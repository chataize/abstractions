namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a chat session with messages and methods to add messages from different roles.
/// </summary>
/// <typeparam name="TMessage">The type representing a chat message.</typeparam>
/// <typeparam name="TFunctionCall">The type representing a function call.</typeparam>
/// <typeparam name="TFunctionResult">The type representing a function result.</typeparam>
public interface IChat<TMessage, TFunctionCall, TFunctionResult>
    where TMessage : IChatMessage<TFunctionCall, TFunctionResult>
    where TFunctionCall : IFunctionCall
    where TFunctionResult : IFunctionResult
{
    /// <summary>
    /// Gets or sets the optional identifier used to help OpenAI monitor for abuse.
    /// </summary>
    public string? UserTrackingId { get; set; }

    /// <summary>
    /// Gets or sets the collection of messages that belong to the chat.
    /// </summary>
    public ICollection<TMessage> Messages { get; set; }

    /// <summary>
    /// Asynchronously adds a system message to the chat.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromSystemAsync(string message, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Asynchronously adds a user message to the chat.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromUserAsync(string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    /// <summary>
    /// Asynchronously adds a user message with a custom display name.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromUserAsync(string userName, string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    /// <summary>
    /// Asynchronously adds a chatbot-generated message to the chat.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromChatbotAsync(string message, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Asynchronously adds a chatbot message representing a function call.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromChatbotAsync(TFunctionCall functionCall, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Asynchronously adds a chatbot message containing multiple function calls.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromChatbotAsync(IEnumerable<TFunctionCall> functionCalls, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Asynchronously adds a message containing the result of a function execution.
    /// Should be used only if an asynchronous message-added callback is defined.
    /// </summary>
    public ValueTask<TMessage> FromFunctionAsync(TFunctionResult functionResult, PinLocation pinLocation = PinLocation.None);
}
