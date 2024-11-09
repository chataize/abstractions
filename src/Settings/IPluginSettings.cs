namespace ChatAIze.Abstractions.Settings;

public interface IPluginSettings
{
    public ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    public ValueTask SetAsync<T>(string key, T? value, CancellationToken cancellationToken = default);
}
