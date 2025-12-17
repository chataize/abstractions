namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a static block of text in a settings UI.
/// </summary>
/// <remarks>
/// This element is informational only and does not produce a stored value.
/// </remarks>
public interface ISettingsParagraph : ISetting
{
    /// <summary>
    /// Gets the paragraph text to render.
    /// </summary>
    public string? Content { get; }
}
