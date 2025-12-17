namespace ChatAIze.Abstractions.Databases.Enums;

/// <summary>
/// Additional options that control how a database filter compares values.
/// </summary>
/// <remarks>
/// Not every host supports every option. ChatAIze.Chatbot currently supports case-insensitive and diacritic-insensitive comparisons.
/// </remarks>
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
