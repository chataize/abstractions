using System.Text.Json;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a condition that must be evaluated before a function can be executed.
/// </summary>
public interface IFunctionCondition
{
    /// <summary>
    /// Gets the unique identifier of the condition.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the title of the condition, used for display in the dashboard interface only.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the optional description of the condition, providing additional context or explanation.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the optional icon URL used to visually represent the condition in the dashboard UI.
    /// </summary>
    public string? IconUrl { get; }

    /// <summary>
    /// Gets the delegate that contains the logic used to evaluate the condition.
    /// </summary>
    public Delegate Callback { get; }

    /// <summary>
    /// Gets a function that provides the configurable settings for this condition.
    /// </summary>
    /// <remarks>
    /// This is used by the chatbot dashboard to render the appropriate UI for configuring the condition when it is added to a function.
    /// </remarks>
    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<ISetting>> SettingsCallback { get; }
}
