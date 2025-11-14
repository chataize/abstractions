using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Represents a chatbot plugin that provides settings, functions, actions, and conditions to extend chatbot capabilities.
/// </summary>
/// <remarks>
/// When a plugin DLL is loaded, the chatbot attempts to discover and instantiate the plugin using the following order:
/// <list type="number">
///   <item><description>If a class implementing <see cref="IAsyncPluginLoader"/> is found, its <c>LoadAsync</c> method is called.</description></item>
///   <item><description>If not, but a class implementing <see cref="IPluginLoader"/> exists, its <c>Load</c> method is used.</description></item>
///   <item><description>If no loader is present, the chatbot attempts to automatically construct the plugin class directly.</description></item>
/// </list>
/// This allows for dynamic plugin initialization and customization at load time if needed.
/// </remarks>
public interface IChatbotPlugin
{
    /// <summary>
    /// Gets the unique identifier of the plugin.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the display title of the plugin.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the optional description of the plugin.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the optional icon URL used to visually represent the plugin in the UI.
    /// </summary>
    public string? IconUrl { get; }

    /// <summary>
    /// Gets the optional website URL associated with the plugin or its author.
    /// </summary>
    public string? Website { get; }

    /// <summary>
    /// Gets the optional name of the plugin author.
    /// </summary>
    public string? Author { get; }

    /// <summary>
    /// Gets the version number of the plugin.
    /// </summary>
    public Version Version { get; }

    /// <summary>
    /// Gets the date and time when the plugin was initially released, if known.
    /// </summary>
    public DateTimeOffset? ReleaseTime { get; }

    /// <summary>
    /// Gets the date and time when the plugin was last updated, if applicable.
    /// </summary>
    public DateTimeOffset? LastUpdateTime { get; }

    /// <summary>
    /// Gets a callback that returns the settings for the plugin.
    /// </summary>
    /// <remarks>
    /// Used by the chatbot dashboard to dynamically render the plugin's settings UI.
    /// </remarks>
    public Func<IChatbotContext, ValueTask<IReadOnlyCollection<ISetting>>> SettingsCallback { get; }

    /// <summary>
    /// Gets a callback that returns the list of functions provided by the plugin.
    /// </summary>
    /// <remarks>
    /// Called by the chatbot to retrieve callable functions exposed by the plugin.
    /// </remarks>
    public Func<IChatContext, ValueTask<IReadOnlyCollection<IChatFunction>>> FunctionsCallback { get; }

    /// <summary>
    /// Gets a callback that returns the list of actions provided by the plugin.
    /// </summary>
    /// <remarks>
    /// Called by the function builder UI to populate the list of available plugin actions.
    /// </remarks>
    public Func<IChatbotContext, ValueTask<IReadOnlyCollection<IFunctionAction>>> ActionsCallback { get; }

    /// <summary>
    /// Gets a callback that returns the list of conditions provided by the plugin.
    /// </summary>
    /// <remarks>
    /// Called by the function builder UI to populate the list of available plugin conditions.
    /// </remarks>
    public Func<IChatbotContext, ValueTask<IReadOnlyCollection<IFunctionCondition>>> ConditionsCallback { get; }
}
