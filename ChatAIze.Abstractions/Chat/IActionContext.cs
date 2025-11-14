using System.Text.Json;

namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the execution context for a function's actions within a chat, including state tracking, results, and shared placeholders.
/// </summary>
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
    /// Gets the index of the previously executed action.
    /// </summary>
    public int PreviousActionIndex { get; }

    /// <summary>
    /// Gets the index of the action currently being executed.
    /// </summary>
    public int CurrentActionIndex { get; }

    /// <summary>
    /// Gets or sets the index of the next action to be executed.
    /// </summary>
    public int NextActionIndex { get; set; }

    /// <summary>
    /// Gets or sets a human-readable message that describes the current state or progress of the function execution.
    /// </summary>
    /// <remarks>
    /// This value is typically displayed in the chatbot window during function execution.
    /// It reflects the current step or activity being performed, such as "executing action" or "verifying email".
    /// The status can be updated dynamically using <c>SetStatus</c> and may be accompanied by a progress indicator.
    /// </remarks>
    public string? Status { get; set; }

    /// <summary>
    /// Gets the list of actions that belong to the current function.
    /// </summary>
    public IReadOnlyList<IFunctionAction> Actions { get; }

    /// <summary>
    /// Gets the list of results returned by previously executed actions.
    /// </summary>
    public IReadOnlyList<IActionResult> Results { get; }

    /// <summary>
    /// Gets the dictionary of placeholders used to pass data between actions or supply initial values to function parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> Placeholders { get; }

    /// <summary>
    /// Sets the value of a placeholder by serializing the provided object.
    /// </summary>
    /// <param name="id">The identifier of the placeholder.</param>
    /// <param name="value">The value to assign.</param>
    public void SetPlaceholder(string id, object value);

    /// <summary>
    /// Sets the value of a placeholder using a raw <see cref="JsonElement"/>.
    /// </summary>
    /// <param name="id">The identifier of the placeholder.</param>
    /// <param name="value">The JSON value to assign.</param>
    public void SetPlaceholder(string id, JsonElement value);

    /// <summary>
    /// Sets the result of the current action and marks it as successful or failed.
    /// </summary>
    /// <remarks>
    /// If the result is marked as a failure and the function's <c>ContinueOnFailure</c> flag is <c>false</c>,
    /// the function execution will stop immediately after this action.
    /// If <c>ContinueOnFailure</c> is <c>true</c>, execution continues with the next action,
    /// and the failure is recorded in the results.
    /// </remarks>
    /// <param name="isSuccess">A value indicating whether the action was successful.</param>
    /// <param name="value">An optional result value to associate with the action.</param>
    public void SetActionResult(bool isSuccess, object? value = null);

    /// <summary>
    /// Sets the final result of the function execution and marks it as successful or failed.
    /// </summary>
    /// <remarks>
    /// This method records the function's outcome, but it does not stop execution.
    /// Remaining actions will continue to run unless explicitly stopped with <see cref="StopExecution"/>,
    /// the maximum number of actions is reached, or <c>ContinueOnFailure</c> is false and an action fails.
    /// </remarks>
    /// <param name="isSuccess">A value indicating whether the function was successful.</param>
    /// <param name="value">An optional result value.</param>
    public void SetFunctionResult(bool isSuccess, object? value = null);

    /// <summary>
    /// Immediately stops further execution of the function and its remaining actions.
    /// </summary>
    /// <remarks>
    /// This halts function execution regardless of progress or success state.
    /// It should be used when a terminating condition is met, such as user cancellation, failure, or an early return scenario.
    /// </remarks>
    public void StopExecution();
}
