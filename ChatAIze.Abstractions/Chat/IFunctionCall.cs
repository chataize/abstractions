namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents a tool/function call emitted by a language model.
/// </summary>
/// <remarks>
/// Providers represent tool calls differently (OpenAI tool_calls, Gemini function calls, etc.) but the common pieces are:
/// <list type="bullet">
/// <item><description>a tool call id used to correlate call and result,</description></item>
/// <item><description>a function name,</description></item>
/// <item><description>a JSON payload with arguments.</description></item>
/// </list>
/// In the ChatAIze stack argument keys are typically snake_case.
/// </remarks>
public interface IFunctionCall
{
    /// <summary>
    /// Gets or sets the provider-issued tool call identifier (if available).
    /// </summary>
    /// <remarks>
    /// When present, this should be copied to the matching <see cref="IFunctionResult.ToolCallId"/> so the provider can
    /// pair the result with the original call.
    /// </remarks>
    public string? ToolCallId { get; set; }

    /// <summary>
    /// Gets or sets the function name to invoke.
    /// </summary>
    /// <remarks>
    /// Hosts typically compare names in a normalized manner (case-insensitive / snake_case tolerant).
    /// </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the argument payload as a JSON string.
    /// </summary>
    /// <remarks>
    /// The payload is expected to be a JSON object. Parameter names are typically snake_case to match the schema generated
    /// from <see cref="IChatFunction"/> and <see cref="IFunctionParameter"/>.
    /// </remarks>
    public string Arguments { get; set; }
}
