namespace ChatAIze.Abstractions.Settings;

public interface IPluginSettings
{
    public ValueTask<T?> GetAsync<T>(string key);

    public ValueTask SetAsync<T>(string key, T? value);
}
