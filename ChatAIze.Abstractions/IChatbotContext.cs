using System;
using ChatAIze.Abstractions.Databases;
using ChatAIze.Abstractions.Plugins;
using Microsoft.Extensions.Logging;

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

    /// <summary>
    /// Writes a log entry using the application's logging pipeline with the specified severity.
    /// </summary>
    /// <param name="level">The log level.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">An optional exception.</param>
    public void Log(LogLevel level, string message, Exception? exception = null);
}
