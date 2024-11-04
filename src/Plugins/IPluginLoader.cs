namespace ChatAIze.Abstractions.Plugins;

public interface IPluginLoader
{
    public ValueTask<IChatbotPlugin> LoadAsync(CancellationToken cancellationToken = default);
}
