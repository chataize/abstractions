using ChatAIze.Abstractions.Plugins;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Provides runtime information about the current conversation to plugins and workflow callbacks.
/// </summary>
/// <remarks>
/// This interface is the "ambient" context for most extensibility points:
/// <list type="bullet">
/// <item><description><see cref="IChatFunction"/> callbacks can accept an <see cref="IFunctionContext"/> (which derives from this).</description></item>
/// <item><description><see cref="IFunctionAction"/> callbacks can accept an <see cref="IActionContext"/> (which derives from this).</description></item>
/// <item><description><see cref="IFunctionCondition"/> callbacks can accept an <see cref="IConditionContext"/> (which derives from this).</description></item>
/// </list>
/// <para>
/// Always respect <see cref="IsPreview"/> and <see cref="IsCommunicationSandboxed"/> when performing side effects
/// (HTTP calls, sending emails/SMS, writing to external systems).
/// </para>
/// </remarks>
public interface IChatContext : IChatbotContext
{
    /// <summary>
    /// Gets the unique identifier of the current chat session.
    /// </summary>
    public Guid ChatId { get; }

    /// <summary>
    /// Gets the current user context.
    /// </summary>
    public IUserContext User { get; }

    /// <summary>
    /// Gets a value indicating whether the conversation is running in the dashboard preview.
    /// </summary>
    /// <remarks>
    /// In preview mode you should avoid irreversible operations and prefer returning simulated results.
    /// </remarks>
    public bool IsPreview { get; }

    /// <summary>
    /// Gets a value indicating whether debug mode is enabled for the current run.
    /// </summary>
    /// <remarks>
    /// ChatAIze.Chatbot uses this to control how much internal detail is shown in the preview UI.
    /// Plugins can also use it to return extra diagnostics.
    /// </remarks>
    public bool IsDebugModeOn { get; }

    /// <summary>
    /// Gets a value indicating whether outbound communication should be sandboxed.
    /// </summary>
    /// <remarks>
    /// When enabled, the host may redirect emails/SMS to test destinations. Plugins should still avoid sending real messages
    /// and treat this as a signal that the conversation is running in a safe/testing environment.
    /// </remarks>
    public bool IsCommunicationSandboxed { get; }

    /// <summary>
    /// Retrieves a loaded plugin instance by type.
    /// </summary>
    /// <typeparam name="T">The type of plugin to retrieve.</typeparam>
    /// <param name="id">The optional ID of the plugin instance.</param>
    /// <returns>The requested plugin instance, or <c>null</c> if not found.</returns>
    /// <remarks>
    /// This is primarily intended for optional integrations between plugins. Avoid hard dependencies on other plugins being present.
    /// </remarks>
    public T? GetPlugin<T>(string? id = null) where T : IChatbotPlugin;
}
