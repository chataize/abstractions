using ChatAIze.Abstractions.Chat;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Represents a ChatAIze plugin that can contribute settings, tool functions, workflow actions, and conditions.
/// </summary>
/// <remarks>
/// When a plugin assembly is loaded, ChatAIze.Chatbot attempts to discover and instantiate it using the following order:
/// <list type="number">
///   <item><description>If a class implementing <see cref="IAsyncPluginLoader"/> is found, its <c>LoadAsync</c> method is called.</description></item>
///   <item><description>Otherwise, if a class implementing <see cref="IPluginLoader"/> is found, its <c>Load</c> method is called.</description></item>
///   <item><description>Otherwise, the first concrete <see cref="IChatbotPlugin"/> type in the assembly is constructed via <see cref="Activator.CreateInstance(Type)"/>.</description></item>
/// </list>
/// <para>
/// Important:
/// <list type="bullet">
/// <item><description>Plugin types must have a public parameterless constructor in the default host.</description></item>
/// <item><description><see cref="Id"/> must be non-empty and <see cref="Version"/> must be provided, otherwise the host may reject the plugin.</description></item>
/// <item><description>Plugins may be unloaded/reloaded; avoid relying on static global state.</description></item>
/// </list>
/// </para>
/// </remarks>
public interface IChatbotPlugin
{
    /// <summary>
    /// Gets the unique identifier of the plugin.
    /// </summary>
    /// <remarks>
    /// This id is used as the stable key in the dashboard and should not change across versions.
    /// </remarks>
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
    /// Gets the semantic version of the plugin.
    /// </summary>
    /// <remarks>
    /// ChatAIze.Chatbot currently requires a version for loaded plugins.
    /// </remarks>
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
    /// Gets a callback that returns settings for the plugin.
    /// </summary>
    /// <remarks>
    /// Used by the dashboard to dynamically render the plugin's settings UI.
    /// <para>
    /// The <see cref="ISetting.Id"/> values you return typically become keys in <see cref="IPluginSettings"/> and are used to persist
    /// configuration values.
    /// </para>
    /// </remarks>
    public Func<IChatbotContext, ValueTask<IReadOnlyCollection<ISetting>>> SettingsCallback { get; }

    /// <summary>
    /// Gets a callback that returns tool functions provided by the plugin.
    /// </summary>
    /// <remarks>
    /// These functions are exposed to the language model via ChatAIze.GenerativeCS and can be called on-demand during a conversation.
    /// <para>
    /// Function names should be globally unique across all loaded plugins to avoid ambiguity.
    /// </para>
    /// </remarks>
    public Func<IChatContext, ValueTask<IReadOnlyCollection<IChatFunction>>> FunctionsCallback { get; }

    /// <summary>
    /// Gets a callback that returns workflow actions provided by the plugin.
    /// </summary>
    /// <remarks>
    /// Called by the function builder UI to populate the list of available actions that administrators can use in workflows.
    /// </remarks>
    public Func<IChatbotContext, ValueTask<IReadOnlyCollection<IFunctionAction>>> ActionsCallback { get; }

    /// <summary>
    /// Gets a callback that returns workflow conditions provided by the plugin.
    /// </summary>
    /// <remarks>
    /// Called by the function builder UI to populate the list of available preconditions for workflows.
    /// </remarks>
    public Func<IChatbotContext, ValueTask<IReadOnlyCollection<IFunctionCondition>>> ConditionsCallback { get; }
}
