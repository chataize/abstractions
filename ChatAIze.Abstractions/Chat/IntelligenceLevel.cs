namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a coarse "reasoning effort" hint for the language model.
/// </summary>
/// <remarks>
/// This is intentionally provider-agnostic. A host (for example ChatAIze.Chatbot via ChatAIze.GenerativeCS) may map this
/// to provider-specific knobs (reasoning effort, sampling strategy, model choice, etc.) or ignore it.
/// <para>
/// Because support varies by provider and deployment, callers should treat this as a best-effort hint and be prepared for
/// hosts to no-op or throw if a particular mapping is not implemented.
/// </para>
/// </remarks>
public enum IntelligenceLevel
{
    /// <summary>
    /// Lowest reasoning effort (fastest / cheapest).
    /// </summary>
    Low,

    /// <summary>
    /// Balanced reasoning effort for most requests.
    /// </summary>
    Medium,

    /// <summary>
    /// Highest reasoning effort (slowest / most expensive).
    /// </summary>
    High
}
