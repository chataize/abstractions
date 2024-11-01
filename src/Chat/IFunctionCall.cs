namespace ChatAIze.Abstractions.Chat;

public interface IFunctionCall
{
    public string? ToolCallId { get; set; }

    public string Name { get; set; }

    public string Arguments { get; set; }
}
