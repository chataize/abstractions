using System.Text.Json;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Describes a workflow step that can be placed inside a ChatAIze function.
/// </summary>
/// <remarks>
/// Actions are used by ChatAIze.Chatbot's function builder to let administrators compose multi-step workflows
/// (send email, call HTTP endpoint, set placeholders, etc.).
/// <para>
/// The host invokes <see cref="Callback"/> with values from the action placement settings:
/// <list type="bullet">
/// <item><description>The first parameter can be an <see cref="IActionContext"/>.</description></item>
/// <item><description>A <see cref="CancellationToken"/> parameter is supported.</description></item>
/// <item><description>Remaining parameters are bound by name from the settings dictionary (exact match or snake_case).</description></item>
/// </list>
/// </para>
/// <para>
/// Important: because parameter binding uses parameter names, action-setting <see cref="ISetting.Id"/> values should be valid
/// identifier-like keys (letters/digits/underscore). Avoid characters like <c>:</c> that cannot appear in a C# parameter name.
/// </para>
/// </remarks>
public interface IFunctionAction
{
    /// <summary>
    /// Gets the unique identifier of the action.
    /// </summary>
    /// <remarks>
    /// This id is used to persist placements in the dashboard and should be stable across versions.
    /// </remarks>
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
    /// Gets the delegate that implements the action behavior.
    /// </summary>
    /// <remarks>
    /// Return values are typically shown to the model/user unless <see cref="RunsSilently"/> is enabled. Non-string results
    /// are commonly serialized to JSON by the host.
    /// </remarks>
    public Delegate Callback { get; }

    /// <summary>
    /// Gets a function that returns the settings used to configure this action.
    /// </summary>
    /// <remarks>
    /// This callback is used by the dashboard UI (and often at runtime) and may be called frequently.
    /// Keep it deterministic and fast.
    /// <para>
    /// The input dictionary contains the currently configured values for this placement (keyed by setting id).
    /// </para>
    /// </remarks>
    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<ISetting>> SettingsCallback { get; }

    /// <summary>
    /// Gets a function that identifies which placeholders this action produces.
    /// </summary>
    /// <remarks>
    /// Placeholder ids are typically snake_case and should not contain user data.
    /// The dashboard uses this to show what outputs are available to later actions.
    /// </remarks>
    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<string>> PlaceholdersCallback { get; }
}
