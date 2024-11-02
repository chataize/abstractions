namespace ChatAIze.Abstractions.Settings;

public interface IPluginSettings
{
    public ValueTask<object?> GetAsync(string key);

    public ValueTask SetAsync(string key, object? value);
}
