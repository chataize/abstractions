namespace ChatAIze.Abstractions.Chat;

/// <summary>
/// Represents the result of executing a tool/function call.
/// </summary>
/// <remarks>
/// Tool results are typically sent back to the model as a dedicated message with <see cref="ChatRole.Function"/>.
/// The result should be correlated with the originating call via <see cref="ToolCallId"/> when the provider requires it.
/// </remarks>
public interface IFunctionResult
{
    /// <summary>
    /// Gets or sets the provider-issued tool call identifier that produced this result.
    /// </summary>
    public string? ToolCallId { get; set; }

    /// <summary>
    /// Gets or sets the function name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the serialized result payload.
    /// </summary>
    /// <remarks>
    /// This value is consumed by the model, so prefer concise JSON or plain text. When returning complex objects, hosts commonly
    /// serialize them to JSON using <see cref="System.Text.Json"/>.
    /// </remarks>
    public string Value { get; set; }
}
