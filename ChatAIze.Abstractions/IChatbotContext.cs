using System;
using ChatAIze.Abstractions.Databases;
using ChatAIze.Abstractions.Plugins;
using Microsoft.Extensions.Logging;

namespace ChatAIze.Abstractions;

/// <summary>
/// Provides host services and configuration access outside of a specific chat conversation.
/// </summary>
/// <remarks>
/// This context is commonly passed to plugin callbacks that run in the dashboard (for example plugin settings/actions/conditions discovery),
/// where there may not be a concrete end-user chat session.
/// <para>
/// For per-conversation context (chat id, user, preview flags) use <see cref="ChatAIze.Abstractions.Chat.IChatContext"/>.
/// </para>
/// </remarks>
public interface IChatbotContext
{
    /// <summary>
    /// Gets the host-managed plugin settings store.
    /// </summary>
    public IPluginSettings Settings { get; }

    /// <summary>
    /// Gets the database manager used for interacting with custom databases.
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
