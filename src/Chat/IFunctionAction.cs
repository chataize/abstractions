using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionAction : ISettingsContainer
{
    public string Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public Delegate Callback { get; }

    public IReadOnlyCollection<string> Placeholders { get; }
}
