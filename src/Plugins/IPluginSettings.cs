namespace ChatAIze.Abstractions.Plugins;

public interface IPluginSettings
{
    public ValueTask<T> GetAsync<T>(string id, T defaultValue, CancellationToken cancellationToken = default);

    public ValueTask SetAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
