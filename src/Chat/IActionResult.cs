namespace ChatAIze.Abstractions.Chat;

public interface IActionResult
{
    public string Id { get; }

    public object Result { get; }

    public bool IsSuccess { get; }
}
