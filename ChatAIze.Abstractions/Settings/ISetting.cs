namespace ChatAIze.Abstractions.Settings;

/// <summary>
/// Base contract for a setting or UI element that can appear in a ChatAIze settings/form surface.
/// </summary>
/// <remarks>
/// The <see cref="Id"/> is the stable key used by hosts to:
/// <list type="bullet">
/// <item><description>persist values (dashboard plugin settings, action/condition configuration),</description></item>
/// <item><description>return values from interactive forms (<c>IFunctionContext.ShowFormAsync</c>),</description></item>
/// <item><description>bind values into callbacks (actions/conditions).</description></item>
/// </list>
/// <para>
/// Conventions:
/// <list type="bullet">
/// <item><description>For <em>plugin settings</em>, prefer namespacing ids (for example <c>"myplugin:api_key"</c>) to avoid collisions.</description></item>
/// <item><description>For <em>action/condition settings</em> (which are bound to callback parameters), keep ids identifier-like (letters/digits/underscore) so they can map cleanly to C# parameter names.</description></item>
/// </list>
/// </para>
/// </remarks>
public interface ISetting
{
    /// <summary>
    /// Gets the stable identifier/key for this setting.
    /// </summary>
    /// <remarks>
    /// Changing an id is a breaking change for persisted values in most hosts.
    /// </remarks>
    public string Id { get; }
}
