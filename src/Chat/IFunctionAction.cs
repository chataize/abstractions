using System.Text.Json;
using ChatAIze.Abstractions.Settings;

namespace ChatAIze.Abstractions.Chat;

public interface IFunctionAction
{
    public string Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public string? IconUrl { get; }

    public bool RunsSilently { get; }

    public Delegate Callback { get; }

    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<ISetting>> SettingsCallback { get; }

    public Func<IReadOnlyDictionary<string, JsonElement>, IReadOnlyCollection<string>> PlaceholdersCallback { get; }
}
