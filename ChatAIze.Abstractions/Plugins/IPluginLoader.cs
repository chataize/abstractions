namespace ChatAIze.Abstractions.Plugins;

/// <summary>
/// Defines a synchronous entry point for constructing a plugin instance.
/// </summary>
/// <remarks>
/// ChatAIze.Chatbot discovers plugin loaders via reflection when a plugin assembly is loaded.
/// <para>
/// Load order:
/// <list type="number">
/// <item><description>an implementation of <see cref="IAsyncPluginLoader"/></description></item>
/// <item><description>otherwise an implementation of <see cref="IPluginLoader"/></description></item>
/// <item><description>otherwise the first concrete <see cref="IChatbotPlugin"/> type in the assembly</description></item>
/// </list>
/// </para>
/// <para>
/// Important: the default host uses <see cref="Activator.CreateInstance(Type)"/> to create the loader, so the loader type
/// must have a public parameterless constructor and cannot rely on dependency injection.
/// </para>
/// </remarks>
public interface IPluginLoader
{
    /// <summary>
    /// Constructs and returns a fully initialized plugin instance.
    /// </summary>
    public IChatbotPlugin Load();
}
