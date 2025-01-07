namespace ChatAIze.Abstractions.Databases;

public enum ItemAdditionResult
{
    Success,

    TitleAlreadyExists,

    InvalidTitle,

    InvalidDescription,

    InvalidProperties,

    Error,
}
