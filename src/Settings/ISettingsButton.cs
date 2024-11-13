using ChatAIze.Abstractions.UI;

namespace ChatAIze.Abstractions.Settings;

public interface ISettingsButton : ISetting
{
    public string? Title { get; }

    public string? Description { get; }

    public ButtonStyle Style { get; }

    public bool IsDisabled { get; }

    public Func<CancellationToken, ValueTask>? Callback { get; }
}
