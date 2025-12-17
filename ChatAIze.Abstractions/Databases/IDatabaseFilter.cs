using ChatAIze.Abstractions.Databases.Enums;

namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents a single predicate applied when querying database items.
/// </summary>
/// <remarks>
/// Filters are evaluated by the host implementation of <see cref="IDatabaseManager"/>. Because item properties are stored as strings,
/// hosts may apply additional parsing (for example, numeric/date parsing for greater/less comparisons).
/// </remarks>
public interface IDatabaseFilter
{
    /// <summary>
    /// Gets the property name to filter on.
    /// </summary>
    /// <remarks>
    /// Hosts may normalize this value (for example snake_case) before applying the filter.
    /// </remarks>
    public string Property { get; }

    /// <summary>
    /// Gets the comparison operator to apply.
    /// </summary>
    public FilterType Type { get; }

    /// <summary>
    /// Gets the filter value (when applicable).
    /// </summary>
    /// <remarks>
    /// Some filter types (for example <see cref="FilterType.Contains"/>) treat <see langword="null"/> / empty as "property exists".
    /// Exact behavior is host-defined.
    /// </remarks>
    public string? Value { get; }

    /// <summary>
    /// Gets additional filter options (case/diacritic handling, etc.).
    /// </summary>
    public FilterOptions Options { get; }
}
