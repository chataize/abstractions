using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionAction
{
    public string Id { get; }

    public string Title { get; }

    public Delegate Callback { get; }

    public IReadOnlyCollection<ISetting> Settings { get; }
}
