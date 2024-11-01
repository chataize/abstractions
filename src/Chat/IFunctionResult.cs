namespace ChatAIze.Abstractions.Chat;

public interface IFunctionResult
{
    public string? ToolCallId { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }
}
