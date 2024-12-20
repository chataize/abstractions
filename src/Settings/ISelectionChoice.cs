namespace ChatAIze.Abstractions.Settings;

public interface ISelectionChoice
{
    public string? Title { get; }

    public string Value { get; }

    public bool IsDisabled { get; }
}
