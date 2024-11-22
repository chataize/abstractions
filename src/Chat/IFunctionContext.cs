using ChatAIze.Abstractions.Retrieval;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionContext : IConditionContext
{
    public string SystemMessage { get; set; }

    public ICollection<IQuickReply> QuickReplies { get; set; }

    public ValueTask<IRetrievalResult> SearchKnowledgeAsync(string query, ICollection<string>? keywords = null, CancellationToken cancellationToken = default);

    public void SetLanguageModel(IntelligenceProvider provider, string model);

    public void SetStatus(string? status, double? progress = null);

    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    public ValueTask ShowFeedbackAsync(CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    public ValueTask<(bool, IDictionary<string, object>)> ShowFormAsync(string title, string confirmText = "Confirm", string cancelText = "Cancel", CancellationToken cancellationToken = default, params IReadOnlyCollection<ISetting> settings);

    public ValueTask SetUserPropertyAsync<T>(string id, T? value, CancellationToken cancellationToken = default);
}
