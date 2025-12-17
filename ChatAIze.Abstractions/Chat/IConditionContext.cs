namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Context passed to <see cref="IFunctionCondition"/> callbacks.
/// </summary>
/// <remarks>
/// Conditions are evaluated before executing a workflow/function to decide whether it is allowed for the current user and chat.
/// This interface intentionally does not add additional mutating APIs beyond <see cref="IChatContext"/>.
/// </remarks>
public interface IConditionContext : IChatContext { }
