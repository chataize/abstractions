namespace ChatAIze.Abstractions.Chat;

public interface IActionContext : IFunctionContext
{
    public IReadOnlyCollection<IActionResult> Results { get; }

    public void SetPlaceholder(string id, object? value);

    public void SetSuccess(bool isSuccess);
}
