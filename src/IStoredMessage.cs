namespace ChatAIze.Abstractions;

public interface IStoredMessage<TFunctionCall, TFunctionResult> : IChatMessage<TFunctionCall, TFunctionResult> where TFunctionCall : IFunctionCall where TFunctionResult : IFunctionResult
{
    public Guid UserId { get; set; }

    public DateTimeOffset CreationTime { get; set; }
}
