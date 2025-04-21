using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a button element within a settings panel that performs an action when clicked.
/// </summary>
public interface ISettingsButton : ISetting
{
    /// <summary>
    /// Gets the display title of the button, shown in the user interface.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the button's purpose or behavior.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the visual style to apply to the button.
    /// </summary>
    public ButtonStyle Style { get; }

    /// <summary>
    /// Gets a flag indicating whether the button is disabled and not interactive.
    /// </summary>
    public bool IsDisabled { get; }

    /// <summary>
    /// Gets the callback that is invoked asynchronously when the button is clicked.
    /// </summary>
    public Func<CancellationToken, ValueTask> Callback { get; }
}
