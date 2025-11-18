using System.Text.Json;
using ChatAIze.Abstractions.Retrieval;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the context available during a function's execution, including access to documents, prompt customization, user interactions, and status updates.
/// </summary>
public interface IFunctionContext : IConditionContext
{
    /// <summary>
    /// Gets or sets the prompt used for generating the chatbot's next response.
    /// </summary>
    public string Prompt { get; set; }

    /// <summary>
    /// Gets or sets the collection of quick reply options presented to the user.
    /// </summary>
    public ICollection<IQuickReply> QuickReplies { get; set; }

    /// <summary>
    /// Asynchronously searches the knowledge base using semantic search with optional filters and exclusions.
    /// </summary>
    public ValueTask<IRetrievalResult> SearchKnowledgeAsync(string query, string? folder = null, TranslationLanguage language = TranslationLanguage.Unspecified, IReadOnlyCollection<string>? keywords = null, IReadOnlyCollection<Guid>? ignoredChunkIds = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves the content of a document by its unique identifier.
    /// </summary>
    public ValueTask<string?> GetDocumentContentAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves the content of a document by its title.
    /// </summary>
    public ValueTask<string?> GetDocumentContentAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets how much reasoning effort the assistant should apply when generating responses.
    /// Higher levels may produce deeper analysis but can increase processing time and resource usage.
    /// </summary>
    /// <param name="level">The desired reasoning-effort level.</param>
    public void SetIntelligenceLevel(IntelligenceLevel level);

    /// <summary>
    /// Updates the current execution status and optional progress value.
    /// </summary>
    /// <remarks>
    /// The status is typically shown in the chatbot window, but its visibility can be disabled by the chatbot administrator through the dashboard.
    /// </remarks>
    public void SetStatus(string? status, double? progress = null);

    /// <summary>
    /// Prompts the user to verify their email address via a popup form. The user enters an email address and confirms it using a 6-digit code.
    /// </summary>
    /// <returns><c>true</c> if the email was successfully verified; otherwise, <c>false</c>.</returns>
    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a CAPTCHA popup to confirm user authenticity.
    /// </summary>
    /// <returns><c>true</c> if the CAPTCHA was successfully completed; otherwise, <c>false</c>.</returns>
    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a feedback window where the user can submit comments about their chatbot experience.
    /// </summary>
    public ValueTask ShowFeedbackAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Shows a confirmation dialog with "Yes" and "No" options to confirm the user's intent before proceeding.
    /// </summary>
    /// <returns><c>true</c> if the user selects "Yes"; otherwise, <c>false</c>.</returns>
    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a customizable dialog with input fields based on provided settings, allowing the user to submit structured data.
    /// </summary>
    /// <returns>A tuple where the first value indicates whether the form was submitted, and the second contains the user-provided values.</returns>
    public ValueTask<(bool, IDictionary<string, JsonElement>)> ShowFormAsync(string title, string submitText = "Submit", string cancelText = "Cancel", CancellationToken cancellationToken = default, params IReadOnlyCollection<ISetting> settings);
}
