using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionCondition
{
    public string Id { get; }

    public string Title { get; }

    public bool IsPrecondition { get; }

    public Delegate Callback { get; }

    public IReadOnlyCollection<ISetting> Settings { get; }
}
