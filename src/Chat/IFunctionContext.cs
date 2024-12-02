using System.Text.Json;
using ChatAIze.Abstractions.Retrieval;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionContext : IConditionContext
{
    public string SystemMessage { get; set; }

    public ICollection<IQuickReply> QuickReplies { get; set; }

    public ValueTask<IRetrievalResult> SearchKnowledgeAsync(string query, string? folder = null, TranslationLanguage language = TranslationLanguage.Unspecified, IReadOnlyCollection<string>? keywords = null, IReadOnlyCollection<Guid>? ignoredChunkIds = null, CancellationToken cancellationToken = default);

    public ValueTask<string?> GetDocumentContentAsync(Guid id, CancellationToken cancellationToken = default);

    public ValueTask<string?> GetDocumentContentAsync(string title, CancellationToken cancellationToken = default);

    public void SetLanguageModel(IntelligenceProvider provider, string model);

    public void SetStatus(string? status, double? progress = null);

    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    public ValueTask ShowFeedbackAsync(CancellationToken cancellationToken = default);

    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    public ValueTask<(bool, IDictionary<string, JsonElement>)> ShowFormAsync(string title, string submitText = "Submit", string cancelText = "Cancel", CancellationToken cancellationToken = default, params IReadOnlyCollection<ISetting> settings);
}
