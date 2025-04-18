namespace ChatAIze.Abstractions.Chat;

public interface IChatMessage<TFunctionCall, TFunctionResult> where TFunctionCall : IFunctionCall where TFunctionResult : IFunctionResult
{
    public ChatRole Role { get; set; }

    public string? UserName { get; set; }

    public string? Content { get; set; }

    public ICollection<string> ImageUrls { get; set; }

    public ICollection<TFunctionCall> FunctionCalls { get; set; }

    public TFunctionResult? FunctionResult { get; set; }

    public PinLocation PinLocation { get; set; }
}
