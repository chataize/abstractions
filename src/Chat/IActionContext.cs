namespace ChatAIze.Abstractions.Chat;

public interface IActionContext : IConditionContext
{
    public void SetQuickReplies(params IReadOnlyCollection<IQuickReply> quickReplies);

    public ValueTask SetUserPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
