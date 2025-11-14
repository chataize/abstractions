using ChatAIze.Abstractions.Plugins;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the context of an active chat, including chat metadata, user information, and plugin access.
/// </summary>
public interface IChatContext : IChatbotContext
{
    /// <summary>
    /// Gets the unique identifier of the chat session.
    /// </summary>
    public Guid ChatId { get; }

    /// <summary>
    /// Gets the user context associated with the chat session.
    /// </summary>
    public IUserContext User { get; }

    /// <summary>
    /// Gets a value indicating whether the chat is occurring within the chatbot dashboard rather than a deployed environment.
    /// </summary>
    public bool IsPreview { get; }

    /// <summary>
    /// Gets a value indicating whether debug mode is enabled, allowing all function calls and their results to be displayed in the chat preview window.
    /// </summary>
    public bool IsDebugModeOn { get; }

    /// <summary>
    /// Gets a value indicating whether communication is sandboxed, meaning all outbound emails and SMS messages are redirected to test addresses defined in the developer settings.
    /// </summary>
    public bool IsCommunicationSandboxed { get; }

    /// <summary>
    /// Retrieves a plugin of the specified type, optionally using a plugin ID to resolve multiple instances.
    /// </summary>
    /// <typeparam name="T">The type of plugin to retrieve.</typeparam>
    /// <param name="id">The optional ID of the plugin instance.</param>
    /// <returns>The requested plugin instance, or <c>null</c> if not found.</returns>
    public T? GetPlugin<T>(string? id = null) where T : IChatbotPlugin;
}
