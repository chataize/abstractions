namespace ChatAIze.Abstractions.Chat;

public interface IActionContext : IFunctionContext
{
    public IReadOnlyCollection<IActionResult> Results { get; }

    public void SetPlaceholder(string id, object value);

    public void SetActionResult(bool isSuccess, object? value = null);

    public void SetFunctionResult(bool isSuccess, object? value = null);
}
