using System.Text.Json;
using ChatAIze.Abstractions.Retrieval;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Context available while executing a tool/function call.
/// </summary>
/// <remarks>
/// A function (see <see cref="IChatFunction"/>) can accept an <see cref="IFunctionContext"/> parameter to gain access to:
/// <list type="bullet">
/// <item><description>knowledge search and document retrieval,</description></item>
/// <item><description>prompt/UX customization (<see cref="Prompt"/>, <see cref="QuickReplies"/>),</description></item>
/// <item><description>interactive UI prompts (confirmation/captcha/forms),</description></item>
/// <item><description>status/progress reporting.</description></item>
/// </list>
/// <para>
/// Not every host implements every capability. Treat these APIs as best-effort and be prepared for hosts to no-op or throw
/// for features that are not available in a given environment.
/// </para>
/// </remarks>
public interface IFunctionContext : IConditionContext
{
    /// <summary>
    /// Gets or sets the system prompt/instructions used for the next model response.
    /// </summary>
    /// <remarks>
    /// In ChatAIze.Chatbot this is typically persisted per chat as an override for the current run.
    /// </remarks>
    public string Prompt { get; set; }

    /// <summary>
    /// Gets or sets the quick reply suggestions shown to the user after execution.
    /// </summary>
    public ICollection<IQuickReply> QuickReplies { get; set; }

    /// <summary>
    /// Searches the host knowledge base (semantic search).
    /// </summary>
    /// <param name="query">Natural language query.</param>
    /// <param name="folder">Optional folder/category filter. Hosts may require an exact folder name.</param>
    /// <param name="language">Language preference for filtering/search.</param>
    /// <param name="keywords">Optional keyword hints to improve retrieval.</param>
    /// <param name="ignoredChunkIds">Optional chunk ids to exclude (use <see cref="IRetrievalResult.ChunkIds"/> from prior searches to avoid repeats).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A retrieval result containing matched items.</returns>
    public ValueTask<IRetrievalResult> SearchKnowledgeAsync(string query, string? folder = null, TranslationLanguage language = TranslationLanguage.Unspecified, IReadOnlyCollection<string>? keywords = null, IReadOnlyCollection<Guid>? ignoredChunkIds = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a document's full content by id.
    /// </summary>
    public ValueTask<string?> GetDocumentContentAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a document's full content by title.
    /// </summary>
    public ValueTask<string?> GetDocumentContentAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests a change to the model reasoning effort for the remainder of the run.
    /// </summary>
    /// <param name="level">The desired reasoning-effort level.</param>
    /// <remarks>
    /// This is a host hint and may be ignored. Some environments may not support switching this dynamically.
    /// </remarks>
    public void SetIntelligenceLevel(IntelligenceLevel level);

    /// <summary>
    /// Updates the current execution status and (optionally) progress.
    /// </summary>
    /// <remarks>
    /// In ChatAIze.Chatbot the status may be shown in the chat UI while a workflow runs. Visibility can be disabled by administrators.
    /// <para>
    /// When provided, <paramref name="progress"/> is treated as a percentage in the range 0–100.
    /// </para>
    /// </remarks>
    public void SetStatus(string? status, double? progress = null);

    /// <summary>
    /// Prompts the user to verify an email address.
    /// </summary>
    /// <param name="email">Email address to verify.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><c>true</c> if the email was successfully verified; otherwise, <c>false</c>.</returns>
    public ValueTask<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a CAPTCHA challenge (if supported by the host).
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><c>true</c> if the CAPTCHA was successfully completed; otherwise, <c>false</c>.</returns>
    public ValueTask<bool> ShowCaptchaAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens the host feedback UI (if available).
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    public ValueTask ShowFeedbackAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Shows a confirmation dialog to the current user.
    /// </summary>
    /// <param name="title">Dialog title.</param>
    /// <param name="message">Dialog body text.</param>
    /// <param name="yesText">Label for the affirmative button.</param>
    /// <param name="noText">Label for the negative button.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns><c>true</c> if the user selects "Yes"; otherwise, <c>false</c>.</returns>
    public ValueTask<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No", CancellationToken cancellationToken = default);

    /// <summary>
    /// Displays a custom form built from <see cref="ISetting"/> definitions.
    /// </summary>
    /// <param name="title">Dialog title.</param>
    /// <param name="submitText">Submit button label.</param>
    /// <param name="cancelText">Cancel button label.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <param name="settings">Form fields.</param>
    /// <returns>A tuple where the first value indicates whether the form was submitted, and the second contains the user-provided values.</returns>
    /// <remarks>
    /// Returned values are JSON and should be treated as untrusted input. Keys are typically the <see cref="ISetting.Id"/> values
    /// you provided.
    /// </remarks>
    public ValueTask<(bool, IDictionary<string, JsonElement>)> ShowFormAsync(string title, string submitText = "Submit", string cancelText = "Cancel", CancellationToken cancellationToken = default, params IReadOnlyCollection<ISetting> settings);
}
