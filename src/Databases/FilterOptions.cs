namespace ChatAIze.Abstractions.Databases;

[Flags]
public enum FilterOptions
{
    None = 0,

    IgnoreCase = 1,

    IgnoreDiacritics = 2,

    All = IgnoreCase | IgnoreDiacritics
}
