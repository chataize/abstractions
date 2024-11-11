using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Actions;

public interface IFunctionAction
{
    public string Key { get; }

    public string Name { get; }

    public ICollection<IPluginSetting>? Settings { get; }

    public Func<IDictionary<string, object>, ValueTask<object>>? Callback { get; }
}
