namespace ChatAIze.Abstractions;

/// <summary>
/// Defines the access level of a user in a ChatAIze host.
/// </summary>
/// <remarks>
/// ChatAIze.Chatbot uses these roles primarily for dashboard authorization and administrative capabilities.
/// Plugins and workflow conditions can also use <see cref="ChatAIze.Abstractions.Chat.IUserContext.Role"/> to gate functionality.
/// </remarks>
public enum SecurityRole
{
    /// <summary>
    /// No assigned role. The user has no access to dashboard features.
    /// </summary>
    None,

    /// <summary>
    /// Standard user role with access to chatbot functionality but not the dashboard.
    /// </summary>
    User,

    /// <summary>
    /// Support role with limited access to view user activity and assist with issues.
    /// </summary>
    Support,

    /// <summary>
    /// Editor role with permissions to manage chatbot content and configuration.
    /// </summary>
    Editor,

    /// <summary>
    /// Admin role with full access to the dashboard and system management features.
    /// </summary>
    Admin,

    /// <summary>
    /// Developer role with access to advanced settings, diagnostics, and developer tools.
    /// </summary>
    Developer
}
