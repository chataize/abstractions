using ChatAIze.Abstractions.Databases.Enums;

namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents a sorting rule for ordering items in a database query.
/// </summary>
public interface IDatabaseSorting
{
    /// <summary>
    /// Gets the name of the property used for sorting.
    /// </summary>
    public string Property { get; }

    /// <summary>
    /// Gets the sort order to apply (ascending or descending).
    /// </summary>
    public SortOrder Order { get; }
}
