namespace ChatAIze.Abstractions.Chat;

public interface IActionContext : IConditionContext
{
    public ValueTask SetUserPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
