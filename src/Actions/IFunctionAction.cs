using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Actions;

public interface IFunctionAction
{
    public string Key { get; }

    public string Title { get; }

    public ICollection<IPluginSetting>? Settings { get; }

    public Func<IDictionary<string, object>, IActionContext, CancellationToken, ValueTask<object>>? Callback { get; }
}
