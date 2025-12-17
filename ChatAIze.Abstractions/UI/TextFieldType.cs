namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies the intended input type for a text field.
/// </summary>
/// <remarks>
/// Hosts may map this to HTML input types and/or validation behavior. Not all UIs enforce it.
/// </remarks>
public enum TextFieldType
{
    /// <summary>
    /// Plain text input.
    /// </summary>
    Default,

    /// <summary>
    /// Search input.
    /// </summary>
    Search,

    /// <summary>
    /// URL input.
    /// </summary>
    URL,

    /// <summary>
    /// Email input.
    /// </summary>
    Email,

    /// <summary>
    /// Phone input.
    /// </summary>
    Phone,

    /// <summary>
    /// Password input (characters may be masked).
    /// </summary>
    Password
}
