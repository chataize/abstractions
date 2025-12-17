using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a string input field in a settings UI or dynamic form.
/// </summary>
/// <remarks>
/// Values are typically stored by the host as JSON (a string) under <see cref="ISetting.Id"/>.
/// </remarks>
public interface IStringSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, used to provide context or guidance.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the placeholder text displayed in the input field when it is empty.
    /// </summary>
    public string? Placeholder { get; }

    /// <summary>
    /// Gets the default string value for the setting.
    /// </summary>
    public string? DefaultValue { get; }

    /// <summary>
    /// Gets the intended input type (email, URL, password, etc.).
    /// </summary>
    /// <remarks>
    /// Hosts may map this to a specific HTML input type or validation behavior. Not all UIs enforce it.
    /// </remarks>
    public TextFieldType TextFieldType { get; }

    /// <summary>
    /// Gets the maximum number of characters allowed for the input value.
    /// </summary>
    public int MaxLength { get; }

    /// <summary>
    /// Gets the suggested number of visible lines (values &gt; 1 imply a multi-line editor).
    /// </summary>
    public int EditorLines { get; }

    /// <summary>
    /// Gets a flag indicating whether the host should normalize the value to lowercase.
    /// </summary>
    /// <remarks>
    /// This is best-effort and host-dependent.
    /// </remarks>
    public bool IsLowercase { get; }

    /// <summary>
    /// Gets a flag indicating whether the input is disabled.
    /// </summary>
    public bool IsDisabled { get; }
}
