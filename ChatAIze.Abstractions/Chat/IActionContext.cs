using System.Text.Json;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Execution context for workflow actions running inside a function.
/// </summary>
/// <remarks>
/// ChatAIze.Chatbot "integration functions" are composed of <see cref="IFunctionAction"/> steps.
/// During execution the host exposes state (indices, results) and shared storage (<see cref="Placeholders"/>)
/// through this context.
/// <para>
/// In the default ChatAIze host, action callbacks are invoked via <c>ChatAIze.Utilities.Extensions.DelegateExtensions</c>:
/// parameters are bound from the action's settings dictionary by parameter name (exact or snake_case) and a callback may optionally
/// accept an <see cref="IActionContext"/> and/or <see cref="CancellationToken"/>.
/// </para>
/// </remarks>
public interface IActionContext : IFunctionContext
{
    /// <summary>
    /// Gets the function currently being executed.
    /// </summary>
    public IChatFunction CurrentFunction { get; }

    /// <summary>
    /// Gets the action currently being executed within the function.
    /// </summary>
    public IFunctionAction CurrentAction { get; }

    /// <summary>
    /// Gets the index (0-based) of the previously executed action.
    /// </summary>
    public int PreviousActionIndex { get; }

    /// <summary>
    /// Gets the index (0-based) of the action currently being executed.
    /// </summary>
    public int CurrentActionIndex { get; }

    /// <summary>
    /// Gets or sets the index (0-based) of the next action to execute.
    /// </summary>
    /// <remarks>
    /// Changing this value allows jumping forward/backward in the action list.
    /// </remarks>
    public int NextActionIndex { get; set; }

    /// <summary>
    /// Gets or sets a human-readable status message describing the current execution state.
    /// </summary>
    /// <remarks>
    /// In ChatAIze.Chatbot this is typically displayed in the chat UI while a function runs.
    /// Prefer updating status via <see cref="IFunctionContext.SetStatus"/> when you also have progress information.
    /// </remarks>
    public string? Status { get; set; }

    /// <summary>
    /// Gets the list of resolved actions for the current function.
    /// </summary>
    public IReadOnlyList<IFunctionAction> Actions { get; }

    /// <summary>
    /// Gets the list of results from actions that have already executed.
    /// </summary>
    public IReadOnlyList<IActionResult> Results { get; }

    /// <summary>
    /// Gets placeholder values produced by actions and available to later steps.
    /// </summary>
    /// <remarks>
    /// In ChatAIze.Chatbot placeholder ids are typically normalized to snake_case.
    /// The host may treat keys case-insensitively; callers should not rely on casing.
    /// </remarks>
    public IReadOnlyDictionary<string, JsonElement> Placeholders { get; }

    /// <summary>
    /// Sets a placeholder value by serializing the provided object to JSON.
    /// </summary>
    /// <param name="id">The identifier of the placeholder.</param>
    /// <param name="value">The value to assign.</param>
    /// <remarks>
    /// Placeholders are commonly referenced in later action settings using <c>{placeholder_id}</c> syntax.
    /// </remarks>
    public void SetPlaceholder(string id, object value);

    /// <summary>
    /// Sets a placeholder value using a raw <see cref="JsonElement"/>.
    /// </summary>
    /// <param name="id">The identifier of the placeholder.</param>
    /// <param name="value">The JSON value to assign.</param>
    public void SetPlaceholder(string id, JsonElement value);

    /// <summary>
    /// Marks the current action as successful or failed and optionally records a result payload.
    /// </summary>
    /// <remarks>
    /// Hosts decide how failures affect control flow (for example: stop immediately vs. continue-on-failure).
    /// In ChatAIze.Chatbot failures are added to <see cref="Results"/> and may stop execution depending on function configuration.
    /// </remarks>
    /// <param name="isSuccess">A value indicating whether the action was successful.</param>
    /// <param name="value">An optional result value to associate with the action.</param>
    public void SetActionResult(bool isSuccess, object? value = null);

    /// <summary>
    /// Sets the overall function result and success state.
    /// </summary>
    /// <remarks>
    /// In ChatAIze.Chatbot this value becomes the tool result returned to the model (and can override the default
    /// "list of action results" return).
    /// </remarks>
    /// <param name="isSuccess">A value indicating whether the function was successful.</param>
    /// <param name="value">An optional result value.</param>
    public void SetFunctionResult(bool isSuccess, object? value = null);

    /// <summary>
    /// Requests that the host stop executing any remaining actions.
    /// </summary>
    /// <remarks>
    /// Use this for early-exit scenarios (user cancellation, fatal errors, or when the desired outcome is already reached).
    /// </remarks>
    public void StopExecution();
}
