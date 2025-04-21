namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Specifies the AI provider used for generating responses or executing language-related tasks.
/// </summary>
public enum IntelligenceProvider
{
    /// <summary>
    /// Uses OpenAI as the language model provider.
    /// </summary>
    OpenAI,

    /// <summary>
    /// Uses Google as the language model provider.
    /// </summary>
    Google
}
