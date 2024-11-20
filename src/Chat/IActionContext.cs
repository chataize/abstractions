using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ChatAIze.Abstractions.Chat;

public interface IActionContext : IFunctionContext
{
    public IReadOnlyList<IFunctionAction> Actions { get; }

    public IReadOnlyList<IActionResult> Results { get; }

    public IReadOnlyDictionary<string, JsonElement> Placeholders { get; }

    public void AddPlaceholder(string id, object value);

    [OverloadResolutionPriority(1)]
    public void AddPlaceholder(string id, JsonElement value);

    public void SetPlaceholder(string id, object value);

    [OverloadResolutionPriority(1)]
    public void SetPlaceholder(string id, JsonElement value);

    public void SetActionResult(bool isSuccess, object? value = null);

    public void SetFunctionResult(bool isSuccess, object? value = null);

    public void SetNextAction(int index);

    public void StopExecution();
}
