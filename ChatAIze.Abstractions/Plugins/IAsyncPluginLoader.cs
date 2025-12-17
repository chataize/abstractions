namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Defines an asynchronous entry point for constructing a plugin instance.
/// </summary>
/// <remarks>
/// When a plugin assembly is loaded, ChatAIze.Chatbot prefers this interface over <see cref="IPluginLoader"/> so you can
/// perform asynchronous initialization (warm-up, schema discovery, etc.).
/// <para>
/// Important: the default host creates the loader via <see cref="Activator.CreateInstance(Type)"/>, so the loader type must have
/// a public parameterless constructor and cannot rely on dependency injection.
/// </para>
/// </remarks>
public interface IAsyncPluginLoader
{
    /// <summary>
    /// Asynchronously constructs and returns a fully initialized plugin instance.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous load operation.</param>
    public ValueTask<IChatbotPlugin> LoadAsync(CancellationToken cancellationToken = default);
}
