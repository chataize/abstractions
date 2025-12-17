namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a typed chat transcript used by ChatAIze components (storage, tool execution, and LLM providers).
/// </summary>
/// <remarks>
/// Implementations vary:
/// <list type="bullet">
/// <item><description>In-memory chats (for example <c>ChatAIze.GenerativeCS.Models.Chat</c>) typically append messages to <see cref="Messages"/>.</description></item>
/// <item><description>Persistent chats (for example <c>ChatAIze.Chatbot.Entities.Chat</c>) may only <em>create</em> messages and leave persistence/collection management to the caller.</description></item>
/// </list>
/// Treat the <c>FromXxxAsync</c> helpers as "construct a message of a given role", not necessarily "persist it".
/// </remarks>
/// <typeparam name="TMessage">The type representing a chat message.</typeparam>
/// <typeparam name="TFunctionCall">The type representing a function call.</typeparam>
/// <typeparam name="TFunctionResult">The type representing a function result.</typeparam>
public interface IChat<TMessage, TFunctionCall, TFunctionResult>
    where TMessage : IChatMessage<TFunctionCall, TFunctionResult>
    where TFunctionCall : IFunctionCall
    where TFunctionResult : IFunctionResult
{
    /// <summary>
    /// Gets or sets an optional stable end-user identifier forwarded to model providers.
    /// </summary>
    /// <remarks>
    /// This is commonly mapped to provider fields such as OpenAI's <c>user</c> and is used for abuse monitoring, rate limiting,
    /// or safety controls.
    /// <para>
    /// Do not put emails, phone numbers, or other direct PII here. Prefer a pseudonymous identifier (for example a hashed user id).
    /// </para>
    /// </remarks>
    public string? UserTrackingId { get; set; }

    /// <summary>
    /// Gets or sets the message collection that represents the conversation history.
    /// </summary>
    /// <remarks>
    /// Messages are usually stored in chronological order. Some hosts may reorder or pin messages (see <see cref="PinLocation"/>)
    /// when building a provider request.
    /// </remarks>
    public ICollection<TMessage> Messages { get; set; }

    /// <summary>
    /// Creates a system message.
    /// </summary>
    /// <param name="message">Instructional content for the model.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    /// <remarks>
    /// System messages are intended for rules and instructions, not for user-generated content.
    /// </remarks>
    public ValueTask<TMessage> FromSystemAsync(string message, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Creates a user message.
    /// </summary>
    /// <param name="message">User-provided text.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    /// <param name="imageUrls">Optional image URLs to attach to the message (provider support varies).</param>
    /// <remarks>
    /// If you attach image URLs, ensure they are accessible to the host/provider and do not embed secrets in query strings.
    /// </remarks>
    public ValueTask<TMessage> FromUserAsync(string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    /// <summary>
    /// Creates a user message with a display name.
    /// </summary>
    /// <param name="userName">Human-friendly display name (not a stable identifier).</param>
    /// <param name="message">User-provided text.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    /// <param name="imageUrls">Optional image URLs to attach to the message.</param>
    public ValueTask<TMessage> FromUserAsync(string userName, string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    /// <summary>
    /// Creates a chatbot/assistant message containing text.
    /// </summary>
    /// <param name="message">Assistant-generated text.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    public ValueTask<TMessage> FromChatbotAsync(string message, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Creates a chatbot/assistant message that issues a single function/tool call.
    /// </summary>
    /// <param name="functionCall">Tool call requested by the model.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    public ValueTask<TMessage> FromChatbotAsync(TFunctionCall functionCall, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Creates a chatbot/assistant message that issues multiple function/tool calls.
    /// </summary>
    /// <param name="functionCalls">Tool calls requested by the model.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    public ValueTask<TMessage> FromChatbotAsync(IEnumerable<TFunctionCall> functionCalls, PinLocation pinLocation = PinLocation.None);

    /// <summary>
    /// Creates a function/tool result message.
    /// </summary>
    /// <param name="functionResult">Result payload to send back to the model.</param>
    /// <param name="pinLocation">Optional pinning hint used when trimming context.</param>
    /// <remarks>
    /// In provider protocols (for example OpenAI tool calls), results are correlated with the originating call via
    /// <see cref="IFunctionResult.ToolCallId"/>.
    /// </remarks>
    public ValueTask<TMessage> FromFunctionAsync(TFunctionResult functionResult, PinLocation pinLocation = PinLocation.None);
}
