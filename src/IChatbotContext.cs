using ChatAIze.Abstractions.Databases;
using ChatAIze.Abstractions.Plugins;

namespace ChatAIze.Abstractions;

public interface IChatbotContext
{
    public IPluginSettings Settings { get; }

    public IDatabaseManager Databases { get; }
}
