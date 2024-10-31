namespace ChatAIze.Abstractions;

public interface IChatConversation
{
    public ICollection<IChatMessage> Messages { get; }
}
