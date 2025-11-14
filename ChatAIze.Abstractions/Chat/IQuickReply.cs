namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a quick reply option that appears in the chat and can be selected by the user instead of typing a message manually.
/// </summary>
public interface IQuickReply
{
    /// <summary>
    /// Gets the emoji associated with the quick reply, used to visually represent the option.
    /// </summary>
    public string Emoji { get; }

    /// <summary>
    /// Gets the text content of the quick reply that will be sent if selected.
    /// </summary>
    public string Content { get; }
}
