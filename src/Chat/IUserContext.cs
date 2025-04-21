namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents contextual information about the user participating in a chat.
/// </summary>
public interface IUserContext
{
    /// <summary>
    /// Gets the unique identifier of the user.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the user's display name, if available.
    /// </summary>
    public string? DisplayName { get; }

    /// <summary>
    /// Gets the user's email address, if available.
    /// </summary>
    public string? Email { get; }

    /// <summary>
    /// Gets the user's IP address, if available.
    /// </summary>
    public string? IpAddress { get; }

    /// <summary>
    /// Gets the user's country, if resolved.
    /// </summary>
    public string? Country { get; }

    /// <summary>
    /// Gets the user's city, if resolved.
    /// </summary>
    public string? City { get; }

    /// <summary>
    /// Gets the user's preferred language for translation and localization.
    /// </summary>
    public TranslationLanguage Language { get; }

    /// <summary>
    /// Gets the security role assigned to the user, which determines access to the dashboard and administrative features.
    /// </summary>
    public SecurityRole Role { get; }

    /// <summary>
    /// Gets the user's time zone offset from UTC.
    /// </summary>
    public TimeSpan TimeZoneOffset { get; }

    /// <summary>
    /// Asynchronously retrieves a custom property value associated with the user.
    /// </summary>
    public ValueTask<T> GetPropertyAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously sets a custom property value associated with the user.
    /// </summary>
    public ValueTask SetPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
