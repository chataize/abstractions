namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a static paragraph of text rendered in the settings interface.
/// </summary>
/// <remarks>
/// This element is used for informational purposes only and does not represent an editable setting.
/// </remarks>
public interface ISettingsParagraph : ISetting
{
    /// <summary>
    /// Gets the content of the paragraph to be displayed in the settings UI.
    /// </summary>
    public string? Content { get; }
}
