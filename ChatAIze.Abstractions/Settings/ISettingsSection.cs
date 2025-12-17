namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a top-level grouping node in a settings UI.
/// </summary>
/// <remarks>
/// ChatAIze.Chatbot renders sections as prominent headers and then renders <see cref="Settings"/> underneath.
/// Use sections to keep plugin settings organized for administrators.
/// </remarks>
public interface ISettingsSection : ISetting, ISettingsContainer
{
    /// <summary>
    /// Gets the display title of the section.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets an optional description shown under the title.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag indicating whether the section (and typically its children) should be treated as disabled.
    /// </summary>
    /// <remarks>
    /// Not all hosts enforce this automatically; individual settings also carry their own <c>IsDisabled</c> flags.
    /// </remarks>
    public bool IsDisabled { get; }
}
