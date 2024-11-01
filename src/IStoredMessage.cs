namespace ChatAIze.Abstractions;

public interface IStoredMessage<TFunctionCall, TFunctionResult> : IChatMessage<TFunctionCall, TFunctionResult> where TFunctionCall : IFunctionCall where TFunctionResult : IFunctionResult
{
    public Guid Id { get; set; }

    public Guid ChatId { get; set; }

    public DateTimeOffset CreationTime { get; set; }
}
