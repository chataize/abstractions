namespace ChatAIze.Abstractions.Databases;

public enum DatabaseCreationResult
{
    Success,

    TitleAlreadyExists,

    InvalidTitle,

    InvalidDescription,

    Error,
}
