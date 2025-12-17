namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a suggested reply shown as a clickable option in the chat UI.
/// </summary>
/// <remarks>
/// Quick replies are a UX feature: hosts may display them as buttons/chips to reduce typing and steer the conversation.
/// </remarks>
public interface IQuickReply
{
    /// <summary>
    /// Gets an emoji/icon prefix for the suggestion.
    /// </summary>
    /// <remarks>
    /// Use an empty string if you don't want an emoji.
    /// </remarks>
    public string Emoji { get; }

    /// <summary>
    /// Gets the message content that will be sent if the user selects this option.
    /// </summary>
    public string Content { get; }
}
