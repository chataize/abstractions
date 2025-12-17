namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Provides a non-generic default value for a setting.
/// </summary>
/// <remarks>
/// Hosts use this to prefill missing values in settings dictionaries (for example when an action/condition placement is missing
/// a value, or when rendering a form for the first time).
/// <para>
/// The returned value should be JSON-serializable with <see cref="System.Text.Json.JsonSerializer"/>.
/// </para>
/// </remarks>
public interface IDefaultValueObject
{
    /// <summary>
    /// Gets the default value as an <see cref="object"/>.
    /// </summary>
    /// <remarks>
    /// Implementations typically return the same value as their strongly-typed <c>DefaultValue</c> property.
    /// </remarks>
    public object DefaultValueObject { get; }
}
