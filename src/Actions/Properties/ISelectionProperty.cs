using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Actions.Properties;

public interface ISelectionProperty : IActionProperty
{
    public string? Title { get; }

    public string? Description { get; }

    public SelectionSettingStyle Style { get; }

    public string? DefaultValue { get; }

    public bool IsCompact { get; }

    public bool IsDisabled { get; }

    public ICollection<ISelectionChoice>? Choices { get; }
}
