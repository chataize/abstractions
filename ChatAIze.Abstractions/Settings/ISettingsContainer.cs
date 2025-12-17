namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a node that contains child <see cref="ISetting"/> entries.
/// </summary>
/// <remarks>
/// Containers are used to build nested settings UIs (sections/groups) as well as dynamic forms.
/// </remarks>
public interface ISettingsContainer
{
    /// <summary>
    /// Gets the collection of settings contained in this container.
    /// </summary>
    public IReadOnlyCollection<ISetting> Settings { get; }
}
