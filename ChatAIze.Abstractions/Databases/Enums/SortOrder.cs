namespace ChatAIze.Abstractions.Databases.Enums;

/// <summary>
/// Specifies the direction used when sorting query results.
/// </summary>
public enum SortOrder
{
    /// <summary>
    /// Sorts values from lowest to highest (A–Z, 0–9).
    /// </summary>
    Ascending,

    /// <summary>
    /// Sorts values from highest to lowest (Z–A, 9–0).
    /// </summary>
    Descending
}
