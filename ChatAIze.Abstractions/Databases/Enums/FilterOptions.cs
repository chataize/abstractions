namespace ChatAIze.Abstractions.Databases.Enums;

/// <summary>
/// Specifies additional options that affect how a database filter is applied.
/// </summary>
[Flags]
public enum FilterOptions
{
    /// <summary>
    /// No special filtering options are applied.
    /// </summary>
    None = 0,

    /// <summary>
    /// The filter ignores character casing when comparing values.
    /// </summary>
    IgnoreCase = 1,

    /// <summary>
    /// The filter ignores diacritical marks (such as accents) when comparing values.
    /// </summary>
    IgnoreDiacritics = 2,

    /// <summary>
    /// Applies all available filtering options.
    /// </summary>
    All = IgnoreCase | IgnoreDiacritics
}
