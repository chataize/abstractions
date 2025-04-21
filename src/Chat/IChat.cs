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

    /// <summary>
    /// Adds a system message to the chat.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromSystemAsync"/> instead.
    /// </remarks>
    public TMessage FromSystem(string message, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Adds a user message to the chat.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <param name="imageUrls">Optional collection of image URLs attached to the message.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromUserAsync(string, PinLocation, ICollection{string})"/> instead.
    /// </remarks>
    public TMessage FromUser(string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    /// <summary>
    /// Adds a user message with a custom display name.
    /// </summary>
    /// <param name="userName">The display name of the user.</param>
    /// <param name="message">The message content.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <param name="imageUrls">Optional collection of image URLs attached to the message.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromUserAsync(string, string, PinLocation, ICollection{string})"/> instead.
    /// </remarks>
    public TMessage FromUser(string userName, string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    /// <summary>
    /// Adds a chatbot-generated message to the chat.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromChatbotAsync(string, PinLocation)"/> instead.
    /// </remarks>
    public TMessage FromChatbot(string message, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Adds a chatbot message representing a function call.
    /// </summary>
    /// <param name="functionCall">The function call to include in the message.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromChatbotAsync(TFunctionCall, PinLocation)"/> instead.
    /// </remarks>
    public TMessage FromChatbot(TFunctionCall functionCall, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Adds a chatbot message containing multiple function calls.
    /// </summary>
    /// <param name="functionCalls">The collection of function calls to include.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromChatbotAsync(IEnumerable{TFunctionCall}, PinLocation)"/> instead.
    /// </remarks>
    public TMessage FromChatbot(IEnumerable<TFunctionCall> functionCalls, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Adds a message containing the result of a function execution.
    /// </summary>
    /// <param name="functionResult">The function result to include in the message.</param>
    /// <param name="pinLocation">The optional pin location for preserving the message across context limits.</param>
    /// <returns>The added message.</returns>
    /// <remarks>
    /// If an asynchronous message-added callback is defined, consider using <see cref="FromFunctionAsync"/> instead.
    /// </remarks>
    public TMessage FromFunction(TFunctionResult functionResult, PinLocation pinLocation = PinLocation.None);
}
