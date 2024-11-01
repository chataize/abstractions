namespace ChatAIze.Abstractions;

public interface IStoredChat<TMessage, TFunctionCall, TFunctionResult> : IChatConversation<TMessage, TFunctionCall, TFunctionResult> where TMessage : IChatMessage<TFunctionCall, TFunctionResult> where TFunctionCall : IFunctionCall where TFunctionResult : IFunctionResult
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTimeOffset CreationTime { get; set; }
}
