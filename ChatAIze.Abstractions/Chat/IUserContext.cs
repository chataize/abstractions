namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the current end user in a conversation.
/// </summary>
/// <remarks>
/// This context is passed to plugins and workflows so they can make decisions (authorization, personalization, localization).
/// <para>
/// Most fields are optional because not every deployment has the same identity signals (anonymous widget users vs. signed-in dashboard users).
/// Always handle <see langword="null"/> values.
/// </para>
/// <para>
/// The <see cref="GetPropertyAsync{T}"/> / <see cref="SetPropertyAsync{T}"/> APIs are intended for lightweight per-user storage
/// (for example: "last_order_id", "preferred_topic"). Values are host-defined and are typically stored as JSON.
/// </para>
/// </remarks>
public interface IUserContext
{
    /// <summary>
    /// Gets the unique identifier of the user in the host system.
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
    /// Retrieves a custom property value associated with the current user.
    /// </summary>
    /// <typeparam name="T">Expected value type.</typeparam>
    /// <param name="id">Property id (should be stable and namespaced, e.g. <c>"myplugin:last_order_id"</c>).</param>
    /// <param name="defaultValue">Value to return when the property is missing or cannot be deserialized.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The stored value or <paramref name="defaultValue"/>.</returns>
    /// <remarks>
    /// Treat stored values as untrusted input (they may be user-controlled or come from previous plugin versions).
    /// </remarks>
    public ValueTask<T> GetPropertyAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// Stores a custom property value for the current user.
    /// </summary>
    /// <typeparam name="T">Value type.</typeparam>
    /// <param name="id">Property id (should be stable and namespaced, e.g. <c>"myplugin:last_order_id"</c>).</param>
    /// <param name="value">Value to store. Hosts commonly treat <see langword="null"/> as "delete".</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <remarks>
    /// Keep values small and JSON-serializable. Large blobs should be stored in your own persistence layer instead.
    /// </remarks>
    public ValueTask SetPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
