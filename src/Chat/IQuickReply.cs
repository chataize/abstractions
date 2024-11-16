namespace ChatAIze.Abstractions.Chat;

public interface IQuickReply
{
    public string Emoji { get; }

    public string Content { get; }
}
