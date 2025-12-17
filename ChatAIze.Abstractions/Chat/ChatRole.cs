namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Identifies who "speaks" a message in an LLM-style chat transcript.
/// </summary>
/// <remarks>
/// ChatAIze mirrors the role concepts used by providers like OpenAI and Gemini:
/// <list type="bullet">
/// <item><description><see cref="System"/>: instructions and non-user context ("system").</description></item>
/// <item><description><see cref="User"/>: end-user input ("user").</description></item>
/// <item><description><see cref="Chatbot"/>: the assistant/model response ("assistant").</description></item>
/// <item><description><see cref="Function"/>: a tool/function result message ("tool").</description></item>
/// </list>
/// </remarks>
public enum ChatRole
{
    /// <summary>
    /// System message used to steer or constrain the model.
    /// </summary>
    System,

    /// <summary>
    /// End-user message (optionally including image inputs).
    /// </summary>
    User,

    /// <summary>
    /// Assistant/model message.
    /// <para>
    /// In ChatAIze this role may contain plain text (<see cref="IChatMessage{TFunctionCall, TFunctionResult}.Content"/>) and/or
    /// one or more tool calls (<see cref="IChatMessage{TFunctionCall, TFunctionResult}.FunctionCalls"/>).
    /// </para>
    /// </summary>
    Chatbot,

    /// <summary>
    /// Tool result message produced after executing a model-requested function call.
    /// </summary>
    Function
}
