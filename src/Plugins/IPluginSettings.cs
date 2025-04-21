namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Provides access to shared key-value plugin settings used across all plugins in the system.
/// </summary>
public interface IPluginSettings
{
    /// <summary>
    /// Asynchronously retrieves the value associated with the specified setting ID.
    /// </summary>
    /// <typeparam name="T">The expected type of the setting value.</typeparam>
    /// <param name="id">The unique identifier of the setting.</param>
    /// <param name="defaultValue">The value to return if the setting does not exist.</param>
    /// <param name="cancellationToken">A cancellation token for the asynchronous operation.</param>
    /// <returns>The setting value if found; otherwise, the provided <paramref name="defaultValue"/>.</returns>
    public ValueTask<T> GetAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);
}
