using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Plugins;

public interface IPluginLoader
{
    public ValueTask<IChatbotPlugin> LoadAsync(IPluginSettings settings, CancellationToken cancellationToken = default);
}
