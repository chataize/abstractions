using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionCondition
{
    public string Id { get; }

    public string Title { get; }

    public IReadOnlyCollection<ISetting> Settings { get; }

    public Func<IConditionContext, CancellationToken, ValueTask<(bool, string?)>> Callback { get; }
}
