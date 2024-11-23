namespace ChatAIze.Abstractions.Chat;

public interface IUserContext
{
    public Guid Id { get; }

    public string? DisplayName { get; }

    public string? Email { get; }

    public string? IpAddress { get; }

    public string? Country { get; }

    public string? City { get; }

    public TranslationLanguage Language { get; }

    public SecurityRole Role { get; }

    public TimeSpan TimeZoneOffset { get; }

    public ValueTask<T> GetPropertyAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);
}
