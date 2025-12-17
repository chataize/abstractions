using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a button rendered inside a settings UI.
/// </summary>
/// <remarks>
/// In ChatAIze.Chatbot, settings buttons are typically used for admin-only operations such as:
/// <list type="bullet">
/// <item><description>"Test connection"</description></item>
/// <item><description>"Re-index"</description></item>
/// <item><description>"Open external page"</description></item>
/// </list>
/// The callback runs on the server, so keep it idempotent and respect <see cref="CancellationToken"/>.
/// </remarks>
public interface ISettingsButton : ISetting
{
    /// <summary>
    /// Gets the display title of the button.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets an optional description/caption shown under the button.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the visual style to apply.
    /// </summary>
    public ButtonStyle Style { get; }

    /// <summary>
    /// Gets a flag indicating whether the button is disabled.
    /// </summary>
    public bool IsDisabled { get; }

    /// <summary>
    /// Gets the callback invoked when the user clicks the button.
    /// </summary>
    /// <remarks>
    /// Hosts may surface exceptions to the UI; prefer returning failures via logging and safe error handling.
    /// </remarks>
    public Func<CancellationToken, ValueTask> Callback { get; }
}
