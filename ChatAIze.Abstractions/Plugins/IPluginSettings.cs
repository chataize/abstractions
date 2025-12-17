namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Provides read access to host-managed plugin configuration values.
/// </summary>
/// <remarks>
/// In ChatAIze.Chatbot, plugin settings are configured by administrators in the dashboard and stored as JSON keyed by setting id.
/// Plugins can read them at runtime (for example from <see cref="ChatAIze.Abstractions.IChatbotContext.Settings"/> or from an
/// <see cref="ChatAIze.Abstractions.Chat.IChatContext"/> passed to function callbacks).
/// <para>
/// For per-user storage use <c>IUserContext.GetPropertyAsync</c> / <c>IUserContext.SetPropertyAsync</c> instead.
/// </para>
/// </remarks>
public interface IPluginSettings
{
    /// <summary>
    /// Retrieves the value associated with the specified setting id.
    /// </summary>
    /// <typeparam name="T">The expected type of the setting value.</typeparam>
    /// <param name="id">The unique identifier of the setting.</param>
    /// <param name="defaultValue">The value to return if the setting does not exist.</param>
    /// <param name="cancellationToken">A cancellation token for the asynchronous operation.</param>
    /// <returns>The setting value if found; otherwise, the provided <paramref name="defaultValue"/>.</returns>
    /// <remarks>
    /// Values are typically stored as JSON. Treat them as untrusted input (they may come from older versions or manual edits).
    /// </remarks>
    public ValueTask<T> GetAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);
}
