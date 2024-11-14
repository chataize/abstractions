using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionCondition : ISettingsContainer
{
    public string Id { get; }

    public string Title { get; }

    public bool IsPrecondition { get; }

    public Delegate Callback { get; }
}
