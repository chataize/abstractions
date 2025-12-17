namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Hints how a message should be treated when the host prunes a conversation to fit a model context window.
/// </summary>
/// <remarks>
/// ChatAIze hosts commonly need to drop older messages to stay within token limits. Pinning is a prompt-construction concern,
/// not a UI feature.
/// <para>
/// Typical usage:
/// <list type="bullet">
/// <item><description><see cref="Begin"/> for long-lived system instructions (tone, policy, business rules).</description></item>
/// <item><description><see cref="End"/> for information that must remain close to "now" (latest constraints or state).</description></item>
/// <item><description><see cref="Automatic"/> when the host decides where the message belongs.</description></item>
/// </list>
/// </para>
/// </remarks>
public enum PinLocation
{
    /// <summary>
    /// No pinning; the message is eligible to be dropped during context trimming.
    /// </summary>
    None,

    /// <summary>
    /// Host-defined pinning behavior.
    /// <para>
    /// In ChatAIze.Chatbot this is commonly used as a default and may be interpreted as "keep if possible".
    /// </para>
    /// </summary>
    Automatic,

    /// <summary>
    /// Pin near the beginning of the prompt (highest retention).
    /// </summary>
    Begin,

    /// <summary>
    /// Pin near the end of the prompt (kept close to the most recent turns).
    /// </summary>
    End
}
