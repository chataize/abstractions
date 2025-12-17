using ChatAIze.Abstractions.Databases.Enums;

namespace ChatAIze.Abstractions.Databases;

/// <summary>
/// Represents a sorting rule for ordering database query results.
/// </summary>
/// <remarks>
/// Sorting is applied by the host implementation of <see cref="IDatabaseManager"/>.
/// In ChatAIze.Chatbot the <see cref="Property"/> value is expected to be the normalized property key (snake_case) as it appears in
/// <see cref="IDatabaseItem.Properties"/>.
/// </remarks>
public interface IDatabaseSorting
{
    /// <summary>
    /// Gets the property name/key used for sorting.
    /// </summary>
    public string Property { get; }

    /// <summary>
    /// Gets the sort order to apply (ascending or descending).
    /// </summary>
    public SortOrder Order { get; }
}
