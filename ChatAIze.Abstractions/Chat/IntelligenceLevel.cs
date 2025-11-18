namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Specifies how much reasoning effort the assistant should apply when generating a response.
/// Higher levels typically mean deeper analysis at the cost of more time and resources.
/// </summary>
public enum IntelligenceLevel
{
    /// <summary>
    /// Minimal reasoning effort.
    /// Uses fast, shallow reasoning suitable for simple queries and low-cost operations.
    /// </summary>
    Low,

    /// <summary>
    /// Moderate reasoning effort.
    /// Balances depth and speed, suitable for most everyday tasks and typical use cases.
    /// </summary>
    Medium,

    /// <summary>
    /// Maximum reasoning effort.
    /// Uses deeper, more exhaustive reasoning for complex, ambiguous, or critical tasks.
    /// </summary>
    High
}
