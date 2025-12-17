namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a nested grouping node under a section.
/// </summary>
/// <remarks>
/// ChatAIze.Chatbot renders groups as subheaders and then renders <see cref="Settings"/> underneath.
/// </remarks>
public interface ISettingsGroup : ISetting, ISettingsContainer
{
    /// <summary>
    /// Gets the display title of the group.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets an optional description shown under the title.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a flag indicating whether the group (and typically its children) should be treated as disabled.
    /// </summary>
    /// <remarks>
    /// Not all hosts enforce this automatically; individual settings also carry their own <c>IsDisabled</c> flags.
    /// </remarks>
    public bool IsDisabled { get; }
}
