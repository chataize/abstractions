using ChatAIze.Abstractions.Actions.Properties;

namespace ChatAIze.Abstractions.Actions;

public interface IFunctionAction
{
    public string Id { get; }

    public string Title { get; }

    public ICollection<IActionProperty>? Properties { get; }

    public Delegate? Callback { get; }
}
