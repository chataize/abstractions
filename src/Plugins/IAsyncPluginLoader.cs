namespace ChatAIze.Abstractions.Plugins;

public interface IAsyncPluginLoader
{
    public ValueTask<IChatbotPlugin> LoadAsync(CancellationToken cancellationToken = default);
}
