namespace ChatAIze.Abstractions.Databases.Enums;

/// <summary>
/// Specifies the type of comparison to apply in a database filter.
/// </summary>
public enum FilterType
{
    /// <summary>
    /// Matches values that are equal to the filter value.
    /// </summary>
    Equal,

    /// <summary>
    /// Matches values that are not equal to the filter value.
    /// </summary>
    NotEqual,

    /// <summary>
    /// Matches values that are greater than the filter value.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Matches values that are greater than or equal to the filter value.
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// Matches values that are less than the filter value.
    /// </summary>
    LessThan,

    /// <summary>
    /// Matches values that are less than or equal to the filter value.
    /// </summary>
    LessThanOrEqual,

    /// <summary>
    /// Matches values that contain the filter value as a substring.
    /// </summary>
    Contains,

    /// <summary>
    /// Matches values that do not contain the filter value as a substring.
    /// </summary>
    NotContains,

    /// <summary>
    /// Matches values that start with the filter value.
    /// </summary>
    StartsWith,

    /// <summary>
    /// Matches values that do not start with the filter value.
    /// </summary>
    NotStartsWith,

    /// <summary>
    /// Matches values that end with the filter value.
    /// </summary>
    EndsWith,

    /// <summary>
    /// Matches values that do not end with the filter value.
    /// </summary>
    NotEndsWith
}
