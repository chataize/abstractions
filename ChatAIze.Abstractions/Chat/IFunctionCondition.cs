using System.Text.Json;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Describes a guard/condition that can be evaluated before running a function.
/// </summary>
/// <remarks>
/// Conditions are evaluated before executing a workflow function. They are intended to be fast and side-effect free.
/// <para>
/// Callback conventions in the default ChatAIze host:
/// <list type="bullet">
/// <item><description>The first parameter can be an <see cref="IConditionContext"/>.</description></item>
/// <item><description>A <see cref="CancellationToken"/> parameter is supported.</description></item>
/// <item><description>Remaining parameters are bound by name from the settings dictionary (exact match or snake_case).</description></item>
/// </list>
/// </para>
/// <para>
/// Return conventions:
/// <list type="bullet">
/// <item><description>Return <see langword="true"/> to allow execution.</description></item>
/// <item><description>Return <see langword="false"/> or a string/object to deny execution (the host may surface the string as a reason).</description></item>
/// </list>
/// </para>
/// </remarks>
public interface IFunctionCondition
{
    /// <summary>
    /// Gets the unique identifier of the condition.
    /// </summary>
    /// <remarks>
    /// This id is used to persist placements in the dashboard and should be stable across versions.
    /// </remarks>
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
    /// Gets the delegate that evaluates the condition.
    /// </summary>
    public Delegate Callback { get; }

    /// <summary>
    /// Gets a function that returns the settings used to configure this condition.
    /// </summary>
    /// <remarks>
    /// This callback is used by the dashboard UI and may be called frequently. Keep it deterministic and fast.
    /// The input dictionary contains the currently configured values for this placement (keyed by setting id).
    /// </remarks>
    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<ISetting>> SettingsCallback { get; }
}
