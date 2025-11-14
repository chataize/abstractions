namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Represents an asynchronous loader for a chatbot plugin.
/// </summary>
/// <remarks>
/// When a plugin DLL is loaded, the chatbot gives priority to <see cref="IAsyncPluginLoader"/> over <see cref="IPluginLoader"/>.
/// If no loader is found, it falls back to automatically instantiating the plugin class.
/// </remarks>
public interface IAsyncPluginLoader
{
    /// <summary>
    /// Asynchronously loads and returns an instance of a chatbot plugin.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous load operation.</param>
    public ValueTask<IChatbotPlugin> LoadAsync(CancellationToken cancellationToken = default);
}
