using ChatAIze.Abstractions.Actions.Properties;

namespace ChatAIze.Abstractions.Actions;

public interface IFunctionAction
{
    public string Key { get; }

    public string Title { get; }

    public ICollection<IActionProperty>? Properties { get; }

    public Delegate? Callback { get; }
}
