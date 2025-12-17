namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a chat transcript that is persisted (for example in a database).
/// </summary>
/// <remarks>
/// ChatAIze.Chatbot uses this shape for its stored chat entities. It extends <see cref="IChat{TMessage, TFunctionCall, TFunctionResult}"/>
/// with identifiers and basic lifecycle metadata.
/// </remarks>
/// <typeparam name="TMessage">The type representing a chat message.</typeparam>
/// <typeparam name="TFunctionCall">The type representing a function call.</typeparam>
/// <typeparam name="TFunctionResult">The type representing a function result.</typeparam>
public interface IStoredChat<TMessage, TFunctionCall, TFunctionResult> : IChat<TMessage, TFunctionCall, TFunctionResult>
    where TMessage : IChatMessage<TFunctionCall, TFunctionResult>
    where TFunctionCall : IFunctionCall
    where TFunctionResult : IFunctionResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the chat.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who owns the chat.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the chat was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }
}
