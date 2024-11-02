namespace ChatAIze.Abstractions.Chat;

public interface IExecutionContext
{
    public Guid ChatId { get; }

    public Guid UserId { get; }

    public string? UserName { get; }

    public string? UserEmail { get; }

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No");

    public ValueTask<bool> VerifyEmailAsync(string email);
}
