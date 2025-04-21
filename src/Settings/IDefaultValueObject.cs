namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents an object that provides a default value for a setting or configurable component.
/// </summary>
public interface IDefaultValueObject
{
    /// <summary>
    /// Gets the default value as an <see cref="object"/>.
    /// </summary>
    public object DefaultValueObject { get; }
}
