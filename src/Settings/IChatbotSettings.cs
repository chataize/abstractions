namespace ChatAIze.Abstractions.Settings;

public interface IChatbotSettings
{
    public ValueTask<object?> GetAsync(string key);

    public ValueTask SetAsync(string key, object? value);
}
