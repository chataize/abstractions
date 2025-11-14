namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Represents a synchronous loader for a chatbot plugin.
/// </summary>
/// <remarks>
/// When a plugin DLL is loaded, the chatbot will look for an implementation of <see cref="IAsyncPluginLoader"/> first,
/// then <see cref="IPluginLoader"/>. If neither is found, it attempts to automatically construct the plugin class.
/// </remarks>
public interface IPluginLoader
{
    /// <summary>
    /// Loads and returns an instance of a chatbot plugin.
    /// </summary>
    public IChatbotPlugin Load();
}
