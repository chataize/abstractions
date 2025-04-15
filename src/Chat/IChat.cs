namespace ChatAIze.Abstractions.Chat;

public interface IChat<TMessage, TFunctionCall, TFunctionResult> where TMessage : IChatMessage<TFunctionCall, TFunctionResult> where TFunctionCall : IFunctionCall where TFunctionResult : IFunctionResult
{
    public string? UserTrackingId { get; set; }

    public ICollection<TMessage> Messages { get; set; }

    public ValueTask<TMessage> FromSystemAsync(string message, PinLocation pinLocation = PinLocation.None);

    public ValueTask<TMessage> FromUserAsync(string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    public ValueTask<TMessage> FromUserAsync(string userName, string message, PinLocation pinLocation = PinLocation.None, params ICollection<string> imageUrls);

    public ValueTask<TMessage> FromChatbotAsync(string message, PinLocation pinLocation = PinLocation.None);

    public ValueTask<TMessage> FromChatbotAsync(TFunctionCall functionCall, PinLocation pinLocation = PinLocation.None);

    public ValueTask<TMessage> FromChatbotAsync(IEnumerable<TFunctionCall> functionCalls, PinLocation pinLocation = PinLocation.None);

    public ValueTask<TMessage> FromFunctionAsync(TFunctionResult functionResult, PinLocation pinLocation = PinLocation.None);
}
