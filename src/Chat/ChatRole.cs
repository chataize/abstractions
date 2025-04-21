namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Specifies the role of a participant in a chat conversation.
/// </summary>
public enum ChatRole
{
    /// <summary>
    /// Represents the system role, used for providing initial context or instructions.
    /// </summary>
    System,

    /// <summary>
    /// Represents the user role, typically the person interacting with the chatbot.
    /// </summary>
    User,

    /// <summary>
    /// Represents the chatbot role, responsible for generating responses.
    /// </summary>
    Chatbot,

    /// <summary>
    /// Represents a function or tool role used within the conversation context.
    /// </summary>
    Function
}
