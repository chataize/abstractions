namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a stored chat session that includes persistent identifiers and creation metadata.
/// </summary>
/// <typeparam name="TMessage">The type representing a chat message.</typeparam>
/// <typeparam name="TFunctionCall">The type representing a function call.</typeparam>
/// <typeparam name="TFunctionResult">The type representing a function result.</typeparam>
public interface IStoredChat<TMessage, TFunctionCall, TFunctionResult> : IChat<TMessage, TFunctionCall, TFunctionResult>
    where TMessage : IChatMessage<TFunctionCall, TFunctionResult>
    where TFunctionCall : IFunctionCall
    where TFunctionResult : IFunctionResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the chat session.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who owns the chat.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the chat session was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }
}
