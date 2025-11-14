using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a string-based setting that accepts user input with optional formatting and validation rules.
/// </summary>
public interface IStringSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title of the setting, shown in the user interface.
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
    /// Gets the input field type, such as plain text, email, URL, or password.
    /// </summary>
    public TextFieldType TextFieldType { get; }

    /// <summary>
    /// Gets the maximum number of characters allowed for the input value.
    /// </summary>
    public int MaxLength { get; }

    /// <summary>
    /// Gets the suggested number of visible lines for the input field.
    /// </summary>
    public int EditorLines { get; }

    /// <summary>
    /// Gets a flag indicating whether the input should be automatically converted to lowercase.
    /// </summary>
    public bool IsLowercase { get; }

    /// <summary>
    /// Gets a flag indicating whether the setting is disabled and cannot be modified by the user.
    /// </summary>
    public bool IsDisabled { get; }
}
