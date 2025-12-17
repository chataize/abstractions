using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Represents a setting that stores a list of strings.
/// </summary>
/// <remarks>
/// In ChatAIze.Chatbot this is rendered as a repeatable list editor. Values are typically stored as a JSON array of strings
/// under <see cref="ISetting.Id"/>.
/// </remarks>
public interface IListSetting : ISetting, IDefaultValueObject
{
    /// <summary>
    /// Gets the display title/label.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets the optional description of the setting, providing context or usage instructions.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the placeholder text shown in the input field for each list item.
    /// </summary>
    public string? ItemPlaceholder { get; }

    /// <summary>
    /// Gets the expected input type for list items (e.g., text, email, URL).
    /// </summary>
    public TextFieldType TextFieldType { get; }

    /// <summary>
    /// Gets the maximum number of items allowed in the list.
    /// </summary>
    public int MaxItems { get; }

    /// <summary>
    /// Gets the maximum number of characters allowed for each individual item.
    /// </summary>
    public int MaxItemLength { get; }

    /// <summary>
    /// Gets a flag indicating whether duplicate items are allowed in the list.
    /// </summary>
    public bool AllowDuplicates { get; }

    /// <summary>
    /// Gets a flag indicating whether all list items should be converted to lowercase.
    /// </summary>
    public bool IsLowercase { get; }

    /// <summary>
    /// Gets a flag indicating whether the control is disabled.
    /// </summary>
    public bool IsDisabled { get; }
}
