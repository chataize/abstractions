namespace ChatAIze.Abstractions.UI;

/// <summary>
/// Specifies the expected input type for a text field in the user interface.
/// </summary>
public enum TextFieldType
{
    /// <summary>
    /// A standard single-line text field with no specific formatting.
    /// </summary>
    Default,

    /// <summary>
    /// A text field intended for search input.
    /// </summary>
    Search,

    /// <summary>
    /// A text field intended for URL input.
    /// </summary>
    URL,

    /// <summary>
    /// A text field intended for email address input.
    /// </summary>
    Email,

    /// <summary>
    /// A text field intended for phone number input.
    /// </summary>
    Phone,

    /// <summary>
    /// A text field intended for password input. Characters may be masked.
    /// </summary>
    Password
}
