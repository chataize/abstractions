namespace ChatAIze.Abstractions.Chat;

public interface IStoredChatFunction : IChatFunction
{
    public Guid Id { get; set; }

    public bool IsEnabled { get; set; }

    public bool RequiresVerifiedEmail { get; set; }

    public bool RequiresConfirmation { get; set; }

    public string? ConfirmationTitle { get; set; }

    public string? ConfirmationMessage { get; set; }

    public string? ConfirmationYesText { get; set; }

    public string? ConfirmationNoText { get; set; }

    public int PersonalDailyLimit { get; set; }

    public int SharedDailyLimit { get; set; }
}
