using ChatAIze.Abstractions.Databases;
using ChatAIze.Abstractions.Plugins;

namespace ChatAIze.Abstractions;

/// <summary>
/// Represents the context in which a chatbot operates, including plugin settings and database access.
/// </summary>
public interface IChatbotContext
{
    /// <summary>
    /// Gets the plugin settings associated with the chatbot context.
    /// </summary>
    public IPluginSettings Settings { get; }

    /// <summary>
    /// Gets the database manager used for interacting with data sources.
    /// </summary>
    public IDatabaseManager Databases { get; }
}
