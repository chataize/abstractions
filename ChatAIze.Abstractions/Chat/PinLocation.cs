namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Specifies where a message should be pinned in the conversation to preserve it when context length limits are exceeded.
/// </summary>
public enum PinLocation
{
    /// <summary>
    /// The message is not pinned and may be excluded if context limits are reached.
    /// </summary>
    None,

    /// <summary>
    /// The message stays near its original position for as long as possible,
    /// but may shift as surrounding messages are removed due to context limits.
    /// </summary>
    Automatic,

    /// <summary>
    /// The message is pinned at the beginning of the conversation.
    /// </summary>
    Begin,

    /// <summary>
    /// The message is pinned at the end of the conversation.
    /// </summary>
    End
}
