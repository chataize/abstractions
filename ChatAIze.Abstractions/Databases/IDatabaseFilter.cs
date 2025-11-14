using ChatAIze.Abstractions.Databases.Enums;

namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents a single filter applied to a database query, based on a property, type, and value.
/// </summary>
public interface IDatabaseFilter
{
    /// <summary>
    /// Gets the name of the property to filter on.
    /// </summary>
    public string Property { get; }

    /// <summary>
    /// Gets the type of filter to apply (e.g. equals, contains, greater than).
    /// </summary>
    public FilterType Type { get; }

    /// <summary>
    /// Gets the value to filter against, if applicable.
    /// </summary>
    public string? Value { get; }

    /// <summary>
    /// Gets additional filter configuration options.
    /// </summary>
    public FilterOptions Options { get; }
}
