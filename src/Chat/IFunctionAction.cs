using System.Text.Json;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a single action within a chatbot function, including metadata, execution logic, and dynamic configuration.
/// </summary>
public interface IFunctionAction
{
    /// <summary>
    /// Gets the unique identifier of the action.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the title of the action, typically used for display in the chatbot dashboard.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the optional description of the action, providing additional context for administrators or developers.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the optional icon URL used to visually represent the action in the dashboard UI.
    /// </summary>
    public string? IconUrl { get; }

    /// <summary>
    /// Gets a flag that indicates whether the action should execute without displaying its result to the user.
    /// </summary>
    public bool RunsSilently { get; }

    /// <summary>
    /// Gets the delegate that defines the execution logic of the action.
    /// </summary>
    public Delegate Callback { get; }

    /// <summary>
    /// Gets a function that retrieves the settings (i.e., configurable properties) for this action.
    /// </summary>
    /// <remarks>
    /// This is used by the chatbot dashboard when an action is added to a function, allowing the UI to render
    /// the appropriate controls dynamically based on the returned settings.
    /// </remarks>
    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<ISetting>> SettingsCallback { get; }

    /// <summary>
    /// Gets a function that identifies the placeholders this action produces.
    /// </summary>
    /// <remarks>
    /// This is used by the chatbot dashboard during action configuration to show which output placeholders
    /// will be available to other actions later in the function flow.
    /// </remarks>
    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<string>> PlaceholdersCallback { get; }
}
